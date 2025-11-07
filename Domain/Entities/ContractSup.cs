using Domain.Entities.Enum;

namespace Domain.Entities;

public partial class ContractSup
{
    public int Id { get; set; }

    public string? ContractNo { get; set; }

    public int? SupplierId { get; set; }

    public DateTime? SignatureDate { get; set; }

    public string? DeliveryAddress { get; set; }

    public DateTime? DeliveryTime { get; set; }

    public decimal? DownPayment { get; set; }

    public decimal? NextPayment { get; set; }

    public decimal? LastPayment { get; set; }
    public DateTime? DownPaymentDate {  get; set; }
    public DateTime? NextPaymentDate { get; set; }
    public DateTime? LastPaymentDate { get; set; }
    public decimal? Total { get; set; }

    public byte? CopiesNo { get; set; }

    public byte? KeptNo { get; set; }

    public ContractStatus Status { get; set; }
    public DateTime? CreateDate { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public int? ModifyBy { get; set; }

    public string? Note { get; set; }

    public int? Seller { get; set; }

    public byte? Discount { get; set; }
    public string CustomerContractNo { get; set; }
    public virtual ICollection<ContractSupDetail> ContractSupDetails { get; set; } = new List<ContractSupDetail>();

    public virtual User? CreateByNavigation { get; set; }

    public virtual User? ModifyByNavigation { get; set; }

    public virtual Employee? SellerNavigation { get; set; }

    public virtual Supplier? Supplier { get; set; }

    public virtual ICollection<WarehouseImport> WarehouseImports { get; set; } = new List<WarehouseImport>();
}
