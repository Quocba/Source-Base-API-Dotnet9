namespace Domain.Entities;

public partial class Transfer
{
    public long Id { get; set; }

    public string TransferNo { get; set; } = null!;

    public DateTime? TransferDate { get; set; }

    public int AccountIdSend { get; set; }

    public int AccountIdReceive { get; set; }

    public decimal Cost { get; set; }

    /// <summary>
    /// Phí giao dịch
    /// </summary>
    public int Charge { get; set; }

    public string? Note { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public int? ModifyBy { get; set; }

    public int? ReceiptSend { get; set; }

    public int? ReceiptReceive { get; set; }

    public bool ChargeForSendAccount { get; set; }

    public virtual BankAccount AccountIdReceiveNavigation { get; set; } = null!;

    public virtual BankAccount AccountIdSendNavigation { get; set; } = null!;

    public virtual User? CreateByNavigation { get; set; }

    public virtual User? ModifyByNavigation { get; set; }
    public virtual ICollection<TransferReceipt> TransferReceipt { get; set; }
}
