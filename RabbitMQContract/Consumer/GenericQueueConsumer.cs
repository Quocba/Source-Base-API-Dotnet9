using Domain.Entities.Enum;
using Infrastructure.Context;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RabbitMQContract.Payload.Request;
using System;
using System.Linq;
using System.Threading.Tasks;

public class GenericQueueConsumer : IConsumer<GenericQueueMessage>
{
    private readonly DBContext _context;

    public GenericQueueConsumer(DBContext context)
    {
        _context = context;
    }

    public async Task Consume(ConsumeContext<GenericQueueMessage> context)
    {
        var msg = context.Message;

        var entityType = ResolveType(msg.EntityType);
        if (entityType == null)
        {
            Console.WriteLine($"❌ Không tìm thấy EntityType: {msg.EntityType}");
            return;
        }

        _context.ChangeTracker.Clear();

        var token = JToken.Parse(msg.PayloadJson);
        var jsonArray = token.Type == JTokenType.Array ? (JArray)token : new JArray(token);

        switch (msg.ActionType)
        {
            case QueueActionType.Add:
                foreach (var j in jsonArray)
                {
                    var entity = j.ToObject(entityType, JsonSerializer.Create());
                    if (entity != null)
                        await _context.AddAsync(entity);
                }
                break;

            case QueueActionType.Update:
                foreach (var j in jsonArray)
                {
                    var entity = j.ToObject(entityType, JsonSerializer.Create());
                    if (entity != null)
                        _context.Update(entity);
                }
                break;

            case QueueActionType.Delete:
                var keyProp = _context.Model.FindEntityType(entityType)?.FindPrimaryKey()?.Properties?.FirstOrDefault();
                if (keyProp == null)
                {
                    Console.WriteLine("❌ Không tìm thấy khóa chính cho entity " + entityType.Name);
                    return;
                }

                foreach (var j in jsonArray)
                {
                    var idToken = j[keyProp.Name] ?? j["Id"] ?? j["ID"] ?? j["id"];
                    if (idToken == null) continue;

                    var idVal = Convert.ChangeType(idToken.ToString(), keyProp.ClrType);
                    var entity = await _context.FindAsync(entityType, idVal);

                    if (entity != null)
                    {
                        _context.Remove(entity);
                        Console.WriteLine($"🗑 Xóa {entityType.Name} (PK={idVal})");
                    }
                    else
                    {
                        Console.WriteLine($"⚠️ Không tìm thấy {entityType.Name} (PK={idVal}) để xóa");
                    }
                }
                break;
        }

        try
        {
            var affected = await _context.SaveChangesAsync();
            Console.WriteLine($"✅ Queue {msg.ActionType} => {entityType.Name} (Affected: {affected})");
        }
        catch (DbUpdateException dbEx)
        {
            Console.WriteLine($"💥 Lỗi khi SaveChanges: {dbEx.InnerException?.Message ?? dbEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"💥 Lỗi không xác định: {ex.Message}");
        }
    }

    // Resolve type an toàn (kể cả khi khác assembly)
    private static Type? ResolveType(string typeName)
    {
        var t = Type.GetType(typeName);
        if (t != null) return t;

        foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
        {
            try
            {
                t = asm.GetType(typeName, throwOnError: false, ignoreCase: false);
                if (t != null) return t;
            }
            catch { }
        }

        foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
        {
            try
            {
                t = asm.GetTypes().FirstOrDefault(x =>
                    x.FullName == typeName ||
                    x.Name == typeName ||
                    x.AssemblyQualifiedName == typeName);
                if (t != null) return t;
            }
            catch { }
        }

        return null;
    }
}
