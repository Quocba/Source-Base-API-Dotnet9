using Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ContractStorage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FileID { get; set; }
        public string? ContractNo { get; set; }
        public ContractType ContractType { get; set; }
        public string? Name { get; set; }
        public string? FileUrl { get; set; }
        public ContractFileType FileType { get; set; }
        public DateTime CreatedDate {  get; set; }
        public int CreatedBy { get; set; }
        
    }
}
