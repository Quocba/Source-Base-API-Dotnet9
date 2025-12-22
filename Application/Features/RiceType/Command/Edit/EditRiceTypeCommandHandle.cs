using Application.IService;
using Application.IUnitOfWork;
using Domain.Payload.Base;
using Domain.Share.Common;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using MediatR;
namespace Application.Features.RiceType.Command.Edit
{
    public class EditRiceTypeCommandHandle(ILogger<EditRiceTypeCommand> _logger,
                                           IUnitOfWork.IUnitOfWork _unitOfWork,
                                           IJWTService _jwtSerivce) : IRequestHandler<EditRiceTypeCommand, ApiResponse<string>>
    {
        public async  Task<ApiResponse<string>> Handle(EditRiceTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var riceType = await _unitOfWork.GetRepository<Domain.Entities.RiceType>()
                                                .SingleOrDefaultAsync(predicate: x => x.Id == request.Id && x.IsDeleted != true);

                if (riceType == null)
                {
                    return new ApiResponse<string>
                    {
                        StatusCode = StatusCode.NotFound,
                        Message = "Loại gạo không tồn tại",
                        Data = null!
                    };
                }

                if (!string.IsNullOrWhiteSpace(request.Name))
                {
                    var duplicate = await _unitOfWork.GetRepository<Domain.Entities.RiceType>()
                        .SingleOrDefaultAsync(predicate: x => x.Name == request.Name && x.Id != request.Id && x.IsDeleted != true);

                    if (duplicate != null)
                    {
                        return new ApiResponse<string>
                        {
                            StatusCode = StatusCode.Conflict,
                            Message = "Tên loại gạo đã tồn tại trong hệ thống",
                            Data = null!
                        };
                    }
                }

                riceType.Name = request.Name ?? riceType.Name;
                riceType.Icon = request.Icon ?? riceType.Icon;
                riceType.LastModifiedBy = Guid.Parse(_jwtSerivce.GetUser()!);
                riceType.LastModifiedDate = DateTime.Now;

                _unitOfWork.GetRepository<Domain.Entities.RiceType>().Update(riceType);
                await _unitOfWork.CommitAsync();

                return new ApiResponse<string>
                {
                    StatusCode = StatusCode.OK,
                    Message = "Cập nhật tên loại gạo thành công",
                    Data = request.Name!
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[Edit Rice Type]");
                throw;
            }
        }

    }
}
