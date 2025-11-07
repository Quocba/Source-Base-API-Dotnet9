namespace Domain.Entities;

public partial class QuoteDetail
{
    public long Id { get; set; }

    public int ProductId { get; set; }

    public long QuotationId { get; set; }

    public decimal Quantity { get; set; }

    public decimal Price { get; set; }

    public decimal? Total { get; set; }

    public byte? Vat { get; set; }

    public string? Unit { get; set; }
    public string? Note { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Quotation Quotation { get; set; } = null!;
}
