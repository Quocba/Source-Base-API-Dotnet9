using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ProductImage
{
    public int Id { get; set; }

    public string? ImageList { get; set; }

    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }
}
