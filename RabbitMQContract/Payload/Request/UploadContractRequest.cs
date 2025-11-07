using Domain.Entities.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQContract.Payload.Request
    {
        public class UploadContractRequest
        {
            [Required(ErrorMessage = "Vui lòng nhập file")]
            public IFormFile File { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập số hợp đồng")]
            public string ContractNo {  get; set; }

            [Required(ErrorMessage = "Vui lòng chọn loại hợp đồng")]
            public ContractType ContractType { get; set; }

            [Required(ErrorMessage = "Chọn loại file")]
            public ContractFileType FileType {  get; set; }
        }
    }
