using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Computer
{
    public int Id { get; set; }

    public string? ComputerHash { get; set; }

    public string? ComputerName { get; set; }

    public DateTime? LastLogin { get; set; }

    public string? Description { get; set; }
}
