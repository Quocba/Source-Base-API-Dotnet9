using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class WarehouseReceiptDetail
{
    public long Id { get; set; }

    public long? WarehouseReceiptId { get; set; }

    public int ProductId { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? Price { get; set; }

    public decimal? Vat { get; set; }

    public decimal? Total { get; set; }

    public decimal? OpeningStock { get; set; }
    public string Unit {  get; set; }

    public virtual WarehouseReceipt WarehouseReceipt { get; set; }
}
