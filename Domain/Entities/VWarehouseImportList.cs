using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class VWarehouseImportList
{
    public long Id { get; set; }

    public string? WarehouseImportNo { get; set; }

    public DateOnly ImportDate { get; set; }

    public int? SupplierId { get; set; }

    public int? ContractSupId { get; set; }

    public string? ReceiverName { get; set; }

    public string? ReceiverPhone { get; set; }

    public string? ReceiverAddress { get; set; }

    public decimal? Paid { get; set; }

    public decimal? Total { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public int? ModifyBy { get; set; }

    public string? Note { get; set; }

    public int? EmployeeId { get; set; }

    public decimal? Discount { get; set; }

    public string? Supplier { get; set; }

    public string? ContractNo { get; set; }
}
