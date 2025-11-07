namespace Domain.Entities;

public partial class EmployeeType
{
    public byte Id { get; set; }
    public string? Name { get; set; }
    public int? Status { get; set; }
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
