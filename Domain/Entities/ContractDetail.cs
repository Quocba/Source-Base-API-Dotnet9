namespace Domain.Entities;

public partial class ContractDetail
{
    public long Id { get; set; }

    public int? ContractId { get; set; }

    public int ProductId { get; set; }
    public string Unit { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? Price { get; set; }

    public decimal? Total { get; set; }

    public byte? Vat { get; set; }

    public decimal? Exported { get; set; }
    public decimal? Remaining { get; set; }
    public virtual Contract? Contract { get; set; }

    public virtual Product? Product { get; set; }
}
