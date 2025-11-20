using Application.IGenericRepository;
using Domain.Entities.Enum;
using MassTransit;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.MessageBus;

namespace Infrastructure.GenericRepository
{
    public class QueueRepository : IQueueRepository
    {
        private readonly IBus _bus;
        private readonly ILogger<QueueRepository> _logger;
        public QueueRepository(IBus bus, ILogger<QueueRepository> logger)
        {
            _bus = bus;
            _logger = logger;
        }

        public async Task EnqueueAddAsync<T>(T entity) where T : class
            => await PublishAsync(entity, QueueActionType.Add);

        public async Task EnqueueUpdateAsync<T>(T entity) where T : class
            => await PublishAsync(entity, QueueActionType.Update);

        public async Task EnqueueDeleteAsync<T>(T entity) where T : class
            => await PublishAsync(entity, QueueActionType.Delete);

        public async Task EnqueueRangeAsync<T>(IEnumerable<T> entities, QueueActionType actionType) where T : class
        {
            try
            {
                var msg = new GenericQueueMessage
                {
                    ActionType = actionType,
                    EntityType = typeof(T).AssemblyQualifiedName!,
                    PayloadJson = JsonConvert.SerializeObject(entities, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    })
                };

                await _bus.Publish(msg);
            }
            catch (Exception ex)
            {
                _logger.LogError($"EnqueueRangeAsync {entities}" + ex.InnerException.Message);
                throw;
            }
        }

        private async Task PublishAsync<T>(T entity, QueueActionType actionType) where T : class
        {
            try
            {
                var msg = new GenericQueueMessage
                {
                    ActionType = actionType,
                    EntityType = typeof(T).AssemblyQualifiedName!,
                    PayloadJson = JsonConvert.SerializeObject(entity, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    })
                };

                await _bus.Publish(msg);
            }
            catch (Exception ex)
            {
                _logger.LogError($"EnqueueRangeAsync {entity}" + ex.InnerException.Message);
                throw;
            }
        }
    }
}
