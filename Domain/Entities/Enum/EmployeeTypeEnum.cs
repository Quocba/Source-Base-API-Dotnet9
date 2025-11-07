using System.ComponentModel;

namespace Domain.Entities.Enum
{
    public enum EmployeeTypeEnum
    {
        [Description("Giám đốc")]
        GiamDoc = 1,

        [Description("Phó giám đốc")]
        PhoGiamDoc = 2,

        [Description("Kế toán")]
        KeToan = 3,

        [Description("Nhân viên")]
        NhanVien = 4,

        [Description("Thủ kho")]
        ThuKho = 5
    }
}
