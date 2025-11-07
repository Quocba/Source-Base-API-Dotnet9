namespace Domain.Entities;

public partial class Receipt
{
    public long Id { get; set; }

    public string? ReceiptNo { get; set; }

    public DateTime? ReceiptDate { get; set; }

    public int BankAccountId { get; set; }

    public int? BookKeeping { get; set; }

    public int? Debit { get; set; }

    public int? Credit { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public decimal? Cost { get; set; }

    public string? Reason { get; set; }

    public bool IsReceive { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public int? ModifyBy { get; set; }

    public virtual BankAccount BankAccount { get; set; } = null!;

    public virtual User? CreateByNavigation { get; set; }

    public virtual User? ModifyByNavigation { get; set; }
}
