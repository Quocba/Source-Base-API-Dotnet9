using Application.Payload.Base.Paginate;
using Application.Payload.Response.Position;
using Dapper;
using Domain.Payload.Base;
using Infrastructure.StoreProcedure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Possition.Queries.Gets
{
    public class GetPositionQueryHandle(IUnitOfWork.IUnitOfWork _unitOfWork,
                                        ILogger<GetPositionQueryHandle> _logger)

        : IRequestHandler<GetPositionsQuery, ApiResponse<ProcedurePagingResponse<PositionResponse>>>
    {
        /*
            1. Mở kết nối database
            2. Gọi SP GetPositions để lấy danh sách chức vụ
            3. Đọc và map kết quả trả về sang PositionResponse
            4. Trả về kết quả thành công kèm phân trang
        */
        public async Task<ApiResponse<ProcedurePagingResponse<PositionResponse>>> Handle(GetPositionsQuery request, CancellationToken cancellationToken)
        {
            using var connection = _unitOfWork.Context.Database.GetDbConnection();
            if (connection.State != System.Data.ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            var rows = await connection.QueryAsync<dynamic>(
                DBProcedures.GetPositions,
                new
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    Search = request.Search,
                    Filter = request.Filter
                },
                commandType: System.Data.CommandType.StoredProcedure
                );

            var first = rows.First();
            var totalRecord = (int)first.TotalRecords;

            var response = new ProcedurePagingResponse<PositionResponse>
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalRecord = totalRecord,
                Items = rows.Select(row => new PositionResponse
                {
                    Id = row.Id,
                    Name = row.Name,
                    Description = row.Description,
                    IsDeleted = row.IsDeleted
                }).ToList()
            };

            return new ApiResponse<ProcedurePagingResponse<PositionResponse>>
            {
                StatusCode = 200,
                Message = "Lấy danh sách chức vụ thành công",
                Data = response
            };

        }
    }
}
