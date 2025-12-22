using Discord.Net;
using Domain.Payload.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.RiceType.Command.Create
{
    public class CreateRiceTypeCommand : IRequest<ApiResponse<string>>
    {
        [Required(ErrorMessage = "Vui lòng nhập tên loại gạo")]
        public string Name { get; set; }
        public string? Icon { get; set; }
    }
}
