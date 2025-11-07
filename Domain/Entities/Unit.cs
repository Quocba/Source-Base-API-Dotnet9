namespace Domain.Entities;

public partial class Unit
{
    public short Id { get; set; }

    public string? Name { get; set; }
    public int Status { get; set; }
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
