using Discord.Net;
using Domain.Payload.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Features.Products.Command.Create
{
    public class CreateProductCommand : IRequest<ApiResponse<string>>
    {
        public string SKU { get; set; }
        public string Name { get; set;  }
        public string Description { get; set; }
    }
}
