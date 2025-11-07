using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class VProduct
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Image { get; set; }

    public string? Description { get; set; }

    public string? MoreImage { get; set; }

    public decimal? PurchasePrice { get; set; }

    public decimal? Price { get; set; }

    public decimal? PriceList { get; set; }

    public int? Stock { get; set; }

    public int? Warranty { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public int? ModifyBy { get; set; }

    public byte? Status { get; set; }

    public int? CategoryId { get; set; }

    public string? Manufacturer { get; set; }

    public string? Unit { get; set; }
}
