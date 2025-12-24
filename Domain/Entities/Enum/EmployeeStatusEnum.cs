using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Enum
{
    public enum EmployeeStatusEnum
    {
        [Description("Đang làm việc")]
        Working = 0,
        [Description("Nghỉ Phép")]
        OnLeave = 1,
        [Description("Đã chấm dứt")]
        Terminated = 2
    }
}
