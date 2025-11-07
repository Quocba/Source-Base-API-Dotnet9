using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class WarehouseImportDetail
{
    public long Id { get; set; }

    public long WarehouseImportId { get; set; }

    public int ProductId { get; set; }

    public decimal Quantity { get; set; }

    public decimal? Price { get; set; }

    public decimal? Vat { get; set; }

    public decimal? Total { get; set; }

    public decimal? OpeningStock { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual WarehouseImport WarehouseImport { get; set; } = null!;
}
