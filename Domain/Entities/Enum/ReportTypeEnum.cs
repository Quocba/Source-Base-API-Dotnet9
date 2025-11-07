using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Enum
{
    public enum ReportTypeEnum
    {
        [Description("Nghiệm Thu")]
        Acceptance,

        [Description("Bàn Giao")]
        HandOver,

        [Description("Thanh Lý")]
        Liquidation,

        [Description("Đưa Vào Sử Dụng")]
        Commissioning

    }
}
