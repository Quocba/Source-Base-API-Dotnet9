using Domain.Entities.Enum;

namespace Domain.Entities;

public partial class Quotation
{
    public long Id { get; set; }

    public string? QuotationNo { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public decimal? Total { get; set; }

    public string? Note { get; set; }

    /// <summary>
    /// Nhân viên kinh doanh báo giá
    /// </summary>
    public int? Seller { get; set; }

    /// <summary>
    /// Còn hiệu lực, hết hiệu lực
    /// </summary>
    public QuotationStatus? Status { get; set; }
    public byte? Discount { get; set; }
    /// <summary>
    /// Tiền đã trả
    /// </summary>
    public decimal? Paid { get; set; }
    public decimal? Remaining { get; set; }
    public bool IsDelete { get; set; } = false;

    public virtual User? CreateByNavigation { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual User? ModifyByNavigation { get; set; }

    public virtual ICollection<QuoteDetail> QuoteDetails { get; set; } = new List<QuoteDetail>();

    public virtual Employee? SellerNavigation { get; set; }
}
