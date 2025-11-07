namespace Domain.Entities;

public partial class ContractSupDetail
{
    public long Id { get; set; }

    public int ContractSupId { get; set; }

    public int ProductId { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? Price { get; set; }

    public string? Unit {  get; set; }
    public decimal? Total { get; set; }

    public byte? Vat { get; set; }

    public decimal? Imported { get; set; }

    public virtual ContractSup ContractSup { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
