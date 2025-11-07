using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class AuditTable
{
    public byte Id { get; set; }

    public string? TableName { get; set; }

    public virtual ICollection<ActionLog> ActionLogs { get; set; } = new List<ActionLog>();
}
