namespace Domain.Entities;

public partial class Customer
{
    public int Id { get; set; }

    public string? Phone { get; set; }

    public string? Name { get; set; }

    public string? TaxCode { get; set; }

    public string? CompanyName { get; set; }

    public string? Email { get; set; }

    public string? BankAccount { get; set; }

    public string? BankName { get; set; }

    public string? Address { get; set; }

    public bool? IsPartner { get; set; }

    public int? RewardPoint { get; set; }
    public string? Position { get; set; }
    public string? NickName { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public int? ModifyBy { get; set; }

    public byte? Status { get; set; }

    /// <summary>
    /// Công nợ khách hàng
    /// </summary>
    public decimal? Balance { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual User? CreateByNavigation { get; set; }

    public virtual User? ModifyByNavigation { get; set; }

    public virtual ICollection<Quotation> Quotations { get; set; } = new List<Quotation>();

    public virtual ICollection<WarehouseExport> WarehouseExports { get; set; } = new List<WarehouseExport>();
}
