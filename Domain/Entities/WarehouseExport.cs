using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class WarehouseExport
{
    public long Id { get; set; }

    public string? WarehouseExportNo { get; set; }

    public int? CustomerId { get; set; }

    public int? ContractId { get; set; }

    public DateOnly ExportDate { get; set; }

    public string? ReceiverName { get; set; }

    public string? ReceiverPhone { get; set; }

    /// <summary>
    /// Địa chỉ giao hàng
    /// </summary>
    public string? ReceiverAddress { get; set; }

    /// <summary>
    /// Tiền đã trả
    /// </summary>
    public decimal? Paid { get; set; }

    public decimal? Total { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public int? ModifyBy { get; set; }

    public string? Note { get; set; }

    public int? EmployeeId { get; set; }

    public decimal? Discount { get; set; }

    public virtual Contract? Contract { get; set; }

    public virtual User? CreateByNavigation { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual User? ModifyByNavigation { get; set; }

    public virtual ICollection<WarehouseExportDetail> WarehouseExportDetails { get; set; } = new List<WarehouseExportDetail>();
}
