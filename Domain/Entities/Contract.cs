using Domain.Entities.Enum;

namespace Domain.Entities;

public partial class Contract
{
    public int Id { get; set; }

    public string? ContractNo { get; set; }

    public int? CustomerId { get; set; }

    /// <summary>
    /// Ngày ký
    /// </summary>
    public DateTime? SignatureDate { get; set; }

    /// <summary>
    /// Địa chỉ giao hàng
    /// </summary>
    public string? DeliveryAddress { get; set; }

    /// <summary>
    /// Thời gian giao hàng
    /// </summary>
    public DateTime? DeliveryTime { get; set; }

    /// <summary>
    /// Tiền trả trước (tạm ứng)
    /// </summary>
    public decimal? DownPayment { get; set; }

    /// <summary>
    /// Lần thanh toán kế tiếp (số tiền thanh toán = total - downpayment
    /// </summary>
    public decimal? NextPayment { get; set; }

    public decimal? LastPayment { get; set; }

    public decimal? Total { get; set; }

    /// <summary>
    /// Số lượng bản sao hợp đồng có giá trị pháp lý như nhau
    /// </summary>
    public byte? CopiesNo { get; set; }

    /// <summary>
    /// Số lượng bản công ty lưu giữ
    /// </summary>
    public byte? KeptNo { get; set; }

    /// <summary>
    /// D-đang thực hiện, F-Hoàn thành, W-Đang trong quá trình bảo hành
    /// </summary>
    public ContractStatus? Status { get; set; }
    public DateTime? CreateDate { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public int? ModifyBy { get; set; }

    public string? Note { get; set; }

    public int? Seller { get; set; }

    public byte? Discount { get; set; }
    public DateTime? DownPaymentDate { get; set; }
    public DateTime? NextPaymentDate { get; set; }
    public DateTime? LastPaymentDate { get; set; }
    public virtual ICollection<ContractDetail> ContractDetails { get; set; } = new List<ContractDetail>();
    public virtual User? CreateByNavigation { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual User? ModifyByNavigation { get; set; }

    public virtual Employee? SellerNavigation { get; set; }

    public virtual ICollection<WarehouseExport> WarehouseExports { get; set; } = new List<WarehouseExport>();
}
