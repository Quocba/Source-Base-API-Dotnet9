namespace Domain.Entities;

public partial class WarehouseExportDetail
{
    public long Id { get; set; }

    public long WarehouseExportId { get; set; }

    public int ProductId { get; set; }

    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public byte Vat { get; set; }
    public decimal Total { get; set; }
    public string? Unit { get; set; }
    public virtual Product Product { get; set; } = null!;

    public virtual WarehouseExport WarehouseExport { get; set; } = null!;
}
