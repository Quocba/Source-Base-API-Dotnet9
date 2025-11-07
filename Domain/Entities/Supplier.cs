namespace Domain.Entities;

public partial class Supplier
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? TaxCode { get; set; }

    public string? CompanyName { get; set; }

    public string? Email { get; set; }

    public string? BankAccount { get; set; }

    public string? BankName { get; set; }

    public string? Address { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public int? ModifyBy { get; set; }

    public int? Status { get; set; }

    public decimal? Balance { get; set; }
    public string? Position { get; set; }
    public string? Nickname { get; set; }

    public virtual ICollection<ContractSup> ContractSups { get; set; } = new List<ContractSup>();

    public virtual User? CreateByNavigation { get; set; }

    public virtual User? ModifyByNavigation { get; set; }

    public virtual ICollection<WarehouseImport> WarehouseImports { get; set; } = new List<WarehouseImport>();
}
