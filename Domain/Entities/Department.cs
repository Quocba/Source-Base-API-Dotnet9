namespace Domain.Entities;

public partial class Department
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Status { get; set; }
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    public virtual ICollection<DepartmentPermission> DepartmentPermission { get; set; } = new HashSet<DepartmentPermission>();
}
