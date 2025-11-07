using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class VContractSup
{
    public int Id { get; set; }

    public string? ContractNo { get; set; }

    public string? Supplier { get; set; }

    public DateTime? CreateDate { get; set; }
}
