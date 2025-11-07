using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Image { get; set; }

    public string? Description { get; set; }

    public string? MoreImage { get; set; }

    public decimal? PurchasePrice { get; set; }

    /// <summary>
    /// Tạm hiểu giá nhập gần nhất
    /// </summary>
    public decimal? Price { get; set; }

    /// <summary>
    /// Tạm hiểu là giá bán ra của sản phẩm
    /// </summary>
    public decimal? PriceList { get; set; }

    public short? UnitId { get; set; }

    public decimal? Stock { get; set; }

    public int? Warranty { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public int? ModifyBy { get; set; }

    public byte? Status { get; set; }

    public int? CategoryId { get; set; }

    public string? Manufacturer { get; set; }

    public byte? Vat { get; set; }
    public decimal? Sold { get; set; }

    public virtual ProductCategory? Category { get; set; }

    public virtual ICollection<ContractDetail> ContractDetails { get; set; } = new List<ContractDetail>();

    public virtual ICollection<ContractSupDetail> ContractSupDetails { get; set; } = new List<ContractSupDetail>();

    public virtual User? CreateByNavigation { get; set; }

    public virtual User? ModifyByNavigation { get; set; }

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ICollection<QuoteDetail> QuoteDetails { get; set; } = new List<QuoteDetail>();

    public virtual Unit? Unit { get; set; }

    public virtual ICollection<WarehouseExportDetail> WarehouseExportDetails { get; set; } = new List<WarehouseExportDetail>();

    public virtual ICollection<WarehouseImportDetail> WarehouseImportDetails { get; set; } = new List<WarehouseImportDetail>();
}
