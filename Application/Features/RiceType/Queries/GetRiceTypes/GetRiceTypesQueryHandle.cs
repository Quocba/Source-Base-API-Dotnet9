using Application.Features.Auth.Command.Login;
using Application.Payload.Base.Paginate;
using Application.Payload.Response.RiceTypes;
using Dapper;
using Domain.Payload.Base;
using Domain.Share.Common;
using Infrastructure.StoreProcedure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.Features.RiceType.Queries.GetRiceTypes
{
    public class GetRiceTypesQueryHandle(IUnitOfWork.IUnitOfWork _unitOfWork, 
                                         ILogger<GetRiceTypesQueryHandle> _logger) 
        : IRequestHandler<GetRiceTypesQuery, ApiResponse<ProcedurePagingResponse<RiceTypesResponse>>>
    {
       async Task<ApiResponse<ProcedurePagingResponse<RiceTypesResponse>>> IRequestHandler<GetRiceTypesQuery, ApiResponse<ProcedurePagingResponse<RiceTypesResponse>>>.Handle(GetRiceTypesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                using var connection = _unitOfWork.Context.Database.GetDbConnection();
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                var rows = await connection.QueryAsync<dynamic>(
                    DBProcedures.GetRiceTypes,
                    new
                    {
                        PageNumber = request.PageNumber,
                        PageSize = request.PageSize,
                        Search = request.Search,
                        Filter = request.Filter
                    },
                    commandType: CommandType.StoredProcedure);

                if (!rows.Any())
                {
                    return new ApiResponse<ProcedurePagingResponse<RiceTypesResponse>>
                    {
                        StatusCode = StatusCode.OK,
                        Message = "Không có loại gạo nào",
                        Data = null
                    };
                }

                var first = rows.First();
                int totalRecords = first.TotalRecords;

                var response = new ProcedurePagingResponse<RiceTypesResponse>
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    TotalRecord = totalRecords,
                    Items = rows.Select(x => new RiceTypesResponse
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Icon = x.Icon,
                        IsDeleted = x.IsDeleted,
                        CreatedDate = x.CreatedDate,
                        LastModifiedDate = x.LastModifiedDate,
                        CreatedBy = x.CreatedBy,
                        LastModifiedBy = x.LastModifiedBy
                    }).ToList()
                };

                return new ApiResponse<ProcedurePagingResponse<RiceTypesResponse>>
                {
                    StatusCode = 200,
                    Message = "Lấy danh sách loại gạo thành công",
                    Data = response
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[GetRiceTypesQuery] Lỗi khi lấy danh sách loại gạo");
                return new ApiResponse<ProcedurePagingResponse<RiceTypesResponse>>
                {
                    StatusCode = 500,
                    Message = "Đã xảy ra lỗi khi lấy danh sách loại gạo",
                    Data = null
                };
            }
        }
    }
}
