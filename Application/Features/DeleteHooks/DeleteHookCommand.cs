using Discord.Net;
using Domain.Entities.Enum;
using Domain.Payload.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace Application.Features.DeleteHooks
{
    public class DeleteHookCommand : IRequest<ApiResponse<string>>
    {
        public Guid Id { get; set; }
        public EntityEnum Entity { get; set; }
    }
}
