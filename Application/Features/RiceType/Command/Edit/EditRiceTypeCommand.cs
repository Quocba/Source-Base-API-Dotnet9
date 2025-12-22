using Discord.Net;
using Domain.Payload.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using MediatR;
namespace Application.Features.RiceType.Command.Edit
{
    public class EditRiceTypeCommand : IRequest<ApiResponse<string>>
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Icon { get; set; }
    }
}
