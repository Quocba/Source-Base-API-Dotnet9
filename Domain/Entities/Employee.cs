using Domain.Entities.Enum;

namespace Domain.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    /// <summary>
    /// Kiểu người dùng
    /// </summary>
    public byte? TypeId { get; set; }

    public int? Status { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? LastLogin { get; set; }

    public GenderEnum Gender { get; set; }

    public string? Email { get; set; }

    public byte? RightId { get; set; }

    public int? DepartmentId { get; set; }

    public string? Image { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    /// <summary>
    /// Dùng hiển thị lên hợp đồng
    /// </summary>
    public string? BankAccount { get; set; }

    /// <summary>
    /// Dùng hiển thị lên hợp đồng
    /// </summary>
    public string? BankName { get; set; }

    public decimal? Balance { get; set; }

    public byte? EmployeeTypeId { get; set; }

    public virtual ICollection<ContractSup> ContractSups { get; set; } = new List<ContractSup>();

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual User? CreateByNavigation { get; set; }

    public virtual Department? Department { get; set; }

    public virtual EmployeeType? EmployeeType { get; set; }

    public virtual ICollection<Quotation> Quotations { get; set; } = new List<Quotation>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<WarehouseExport> WarehouseExports { get; set; } = new List<WarehouseExport>();
}
