using Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reports
    {
        public int ID { get; set; }
        public string? ReportNo { get; set; }
        public ReportTypeEnum? Type { get; set; }
        public string? ContractNo {  get; set; }
        public DateTime? Date { get; set; }
        public ContractType? ContractType { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedDate {  get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int Status { get; set; }

        [ForeignKey(nameof(CreateBy))]
        public virtual User? CreateByNavigation { get; set; }
        [ForeignKey(nameof(ModifyBy))]
        public virtual User? ModifyByNavigation { get; set; }
    }
}
