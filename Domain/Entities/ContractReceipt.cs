using Domain.Entities;
using Domain.Entities.Enum;

public class ContractReceipt
{
    public int ID { get; set; }
    public string ReceiptNo { get; set; }
    public DateTime Date { get; set; }
    public ReceiptType Type { get; set; }
    public decimal Amount { get; set; }
    public string? Note { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? ModifyDate { get; set; }
    public int CreateBy { get; set; }
    public virtual User? CreateByNavigation { get; set; }
    public int? ModifyBy { get; set; }
    public virtual User? ModifyByNavigation { get; set; }
    public string ContractNo { get; set; } // thêm cột ContractNo để dễ truy xuất
    public ContractType ContractType { get; set; }
    public int? BankAccountID { get; set; }
    public string CompanyName { get; set; }
    public string CustomerName { get; set; }
    public string Address { get; set; }
    public string Payer { get; set; }
    public string Reason { get; set; }
    public virtual BankAccount? BankAccounts { get; set; }
}
