using Domain.Entities.Enum;

namespace Domain.Entities;

public partial class BankAccount
{
    public int Id { get; set; }

    /// <summary>
    /// Tên gọi của tài khoản
    /// </summary>
    public string? Name { get; set; }
    public string? BankNo { get; set; }

    /// <summary>
    /// Tên ngân hàng
    /// </summary>
    public string? Bank { get; set; }
    public decimal? Balance { get; set; }
    public byte? Status { get; set; }
    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();

    public virtual ICollection<Transfer> TransferAccountIdReceiveNavigations { get; set; } = new List<Transfer>();

    public virtual ICollection<Transfer> TransferAccountIdSendNavigations { get; set; } = new List<Transfer>();
}
