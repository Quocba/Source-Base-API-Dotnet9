using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Config
{
    public string Id { get; set; } = null!;

    public byte[]? Value { get; set; }

    public short? IdDonVi { get; set; }
}
