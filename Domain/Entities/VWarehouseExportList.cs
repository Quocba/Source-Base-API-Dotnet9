using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class VWarehouseExportList
{
    public long Id { get; set; }

    public string? WarehouseExportNo { get; set; }

    public DateOnly ExportDate { get; set; }

    public int? CustomerId { get; set; }

    public int? ContractId { get; set; }

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

    public string? Customer { get; set; }

    public string? ContractNo { get; set; }
}
