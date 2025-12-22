using Application.Payload.Base.Paginate;
using Domain.Payload.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Payload.Response.RiceTypes;
using Application.Payload.Base.BaseRequest;
using MediatR;
namespace Application.Features.RiceType.Queries.GetRiceTypes
{
    public class GetRiceTypesQuery : GetListsRequest, IRequest<ApiResponse<ProcedurePagingResponse<RiceTypesResponse>>>
    {
    }
}
