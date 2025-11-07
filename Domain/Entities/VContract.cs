using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class VContract
{
    public int Id { get; set; }

    public string? ContractNo { get; set; }

    public string? Customer { get; set; }

    public DateTime? CreateDate { get; set; }
}
