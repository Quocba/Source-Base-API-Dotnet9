using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Enum
{
    public enum ContractFileType
    { 

        /// <summary>
        /// Hợp đồng mua bán
        /// </summary>
        Sales = 1,

        /// <summary>
        /// Hợp đồng dịch vụ
        /// </summary>
        Service = 2,

        /// <summary>
        /// Hợp đồng lao động
        /// </summary>
        Employment = 3,

        /// <summary>
        /// Hợp đồng thuê (lease / rental)
        /// </summary>
        Lease = 4,

        /// <summary>
        /// Hợp đồng bảo mật (NDA)
        /// </summary>
        NonDisclosure = 5,

        /// <summary>
        /// Hợp đồng hợp tác
        /// </summary>
        Partnership = 6,

        /// <summary>
        /// Hợp đồng vay mượn / tín dụng
        /// </summary>
        Loan = 7,

        /// <summary>
        /// Hợp đồng bảo trì / bảo hành
        /// </summary>
        Maintenance = 8,

        /// <summary>
        /// Hợp đồng xây dựng
        /// </summary>
        Construction = 9,

        /// <summary>
        /// Hợp đồng nguyên tắc / khung
        /// </summary>
        Master = 10,

        /// <summary>
        /// Phiếu Thu
        /// </summary>
        CollectReceipt = 11,

        /// <summary>
        /// Spend Receipt
        /// </summary>
        SpendReceipt = 12
    }
}
