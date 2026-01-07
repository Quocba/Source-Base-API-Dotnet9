using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public partial class Employee
{
    public Guid Id { get; set; }

    public string? Code { get; set; }

    public string? FullName { get; set; }

    public string? Gender { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? MaritalStatus { get; set; }

    public string? Nationality { get; set; }

    public string? Avatar { get; set; }

    public DateTime? HireDate { get; set; }

    public string? Status { get; set; }

    public Guid DepartmentId { get; set; }

    public Guid PositionId { get; set; }

    public Guid UserId { get; set; }
    public bool? IsDeleted { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public Guid? CreatedBy { get; set; }
    public Guid? LastModifiedBy { get; set; }

    public Guid? WareHouseId { get; set; }

    public virtual Position Position { get; set; }
    public virtual Department Department { get; set; }
   
}
