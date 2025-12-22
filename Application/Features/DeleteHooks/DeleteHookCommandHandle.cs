using Application.IService;
using Domain.Payload.Base;
using Domain.Entities.Enum;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using MediatR;
namespace Application.Features.DeleteHooks
{
    public class DeleteHookCommandHandle(IUnitOfWork.IUnitOfWork _unitOfWork,
                                         ILogger<DeleteHookCommand> _logger,
                                         IJWTService _jwtService)
    : IRequestHandler<DeleteHookCommand, ApiResponse<string>>
    {
        public async  Task<ApiResponse<string>> Handle(DeleteHookCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return new ApiResponse<string>
                {
                    StatusCode = Domain.Share.Common.StatusCode.BadRequest,
                    Message = "Request không hợp lệ",
                    Data = null
                };
            }

            try
            {
                var entityName = request.Entity.ToString();
                var entityType = Type.GetType($"Domain.Entities.{entityName}, Domain");
                if (entityType == null)
                {
                    return new ApiResponse<string>
                    {
                        StatusCode = Domain.Share.Common.StatusCode.BadRequest,
                        Message = $"Entity '{entityName}' không tồn tại trong Domain.Entities",
                        Data = null
                    };
                }

                var getRepoMethod = _unitOfWork.GetType().GetMethod("GetRepository")!.MakeGenericMethod(entityType);
                var repo = getRepoMethod.Invoke(_unitOfWork, null);

                var getByIdAsync = repo!.GetType().GetMethod("GetByIdAsync");
                var entityTask = (Task)getByIdAsync!.Invoke(repo, new object[] { request.Id })!;
                await entityTask.ConfigureAwait(false);
                var entityProp = entityTask.GetType().GetProperty("Result");
                var entity = entityProp!.GetValue(entityTask);

                if (entity == null)
                {
                    return new ApiResponse<string>
                    {
                        StatusCode = Domain.Share.Common.StatusCode.NotFound,
                        Message = $"Không tìm thấy {entityName}",
                        Data = null
                    };
                }

                var deleteHook = repo.GetType().GetMethod("DeleteHook");
                deleteHook!.Invoke(repo, new object[] { request.Id, entity });

                await _unitOfWork.CommitAsync();

                var isDeletedProp = entityType.GetProperty("IsDeleted");
                var isDeleted = isDeletedProp?.GetValue(entity) as bool?;
                var actionMsg = isDeleted == true ? "Xóa mềm" : "Khôi phục";

                return new ApiResponse<string>
                {
                    StatusCode = Domain.Share.Common.StatusCode.OK,
                    Message = $"{actionMsg} {entityName} thành công",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[DeleteHook] Lỗi khi xóa/khôi phục entity {Entity} id={Id}", request.Entity, request.Id);
                return new ApiResponse<string>
                {
                    StatusCode = Domain.Share.Common.StatusCode.InternalServerError,
                    Message = "Đã xảy ra lỗi khi xóa/khôi phục",
                    Data = null
                };
            }
        }
    }
}
