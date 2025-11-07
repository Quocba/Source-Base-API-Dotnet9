using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class VProductHistory
{
    public string? Name { get; set; }

    public decimal? Stock { get; set; }

    public DateOnly? Date { get; set; }

    public int? ProductId { get; set; }

    public decimal Import { get; set; }

    public decimal Export { get; set; }
}
