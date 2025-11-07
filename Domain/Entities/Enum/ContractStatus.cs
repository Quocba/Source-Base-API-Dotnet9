using System.ComponentModel;

namespace Domain.Entities.Enum
{
    public enum ContractStatus
    {
        [Description("Đã xóa")]
        Delete,

        [Description("Bản nháp")]
        Draft,

        [Description("Chờ phê duyệt")]
        WaitingForApproval,

        [Description("Đang thực hiện")]
        OnGoing,

        [Description("Hoàn thành")]
        Completed,

        [Description("Đã hủy")]
        Cancelled
    }
}
