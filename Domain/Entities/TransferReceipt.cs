using Domain.Entities.Enum;

namespace Domain.Entities
{

    public class TransferReceipt
    {
        public long Id { get; set; }
        public string ReceiptNo { get; set; }
        public DateTime Date { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public decimal Cost { get; set; }
        public int Charge { get; set; }
        public TransferReceiptType Type { get; set; }

        public long TransferId { get; set; }   // khóa ngoại
        public virtual Transfer Transfer { get; set; }
    }
}
