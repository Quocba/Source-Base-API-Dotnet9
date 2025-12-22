using System;
using System.Collections.Generic;

namespace Domain.Entities;

public  class User
{
    public Guid Id { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? IsLock { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
