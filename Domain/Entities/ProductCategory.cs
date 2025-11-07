namespace Domain.Entities;

public partial class ProductCategory
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public int? ModifyBy { get; set; }

    public int? Status { get; set; }

    public byte? Vat { get; set; }

    public virtual User? CreateByNavigation { get; set; }

    public virtual User? ModifyByNavigation { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
