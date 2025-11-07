using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Status
{
    public byte Id { get; set; }

    public string? Name { get; set; }

    public string? GroupName { get; set; }
}
