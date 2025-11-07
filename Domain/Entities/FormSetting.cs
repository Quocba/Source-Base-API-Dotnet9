using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class FormSetting
{
    public int Id { get; set; }

    public string? UserType { get; set; }

    public string? UserId { get; set; }

    public string FormName { get; set; } = null!;

    public string ControlName { get; set; } = null!;

    public string PropertyName { get; set; } = null!;

    public string Value { get; set; } = null!;

    public string? Filter { get; set; }
}
