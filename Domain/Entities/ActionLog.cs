namespace Domain.Entities;

public partial class ActionLog
{
    public int Id { get; set; }

    public byte? AuditTableId { get; set; }

    public DateTime? ActionDate { get; set; }

    public int? LoginId { get; set; }

    public string? Action { get; set; }

    public string? Data { get; set; }

    public virtual AuditTable? AuditTable { get; set; }
}
