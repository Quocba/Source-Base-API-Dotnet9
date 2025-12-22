using Application.IService;
using Application.IUnitOfWork;
using Domain.Payload.Base;
using Domain.Share.Common;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RiceType.Command.Create
{
    public class CreateRiceTypeCommandHandle(IUnitOfWork.IUnitOfWork _unitOfWork,
                                             ILogger<CreateRiceTypeCommandHandle> _logger,
                                             IJWTService _jwtService)
        : IRequestHandler<CreateRiceTypeCommand, ApiResponse<string>>
    {
        public async Task<ApiResponse<string>> Handle(CreateRiceTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var checkAlready = await _unitOfWork.GetRepository<Domain.Entities.RiceType>()
                                                     .SingleOrDefaultAsync(
                                                     predicate: x => x.Name.Equals(request.Name)
                                                     );
                if (checkAlready != null)
                {
                    return new ApiResponse<string>
                    {
                        StatusCode = StatusCode.Conflict,
                        Message = "Loại gạo đã tồn tại",
                        Data = request.Name
                    };
                }

                var newRiceType = new Domain.Entities.RiceType
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    Icon = request.Icon,
                    CreatedDate = DateTime.Now,
                    CreatedBy = Guid.Parse(_jwtService.GetUser()!),
                    LastModifiedDate = null,
                    LastModifiedBy = null
                };

                await _unitOfWork.GetRepository<Domain.Entities.RiceType>().AddAsync(newRiceType);
                await _unitOfWork.CommitAsync();

                return new ApiResponse<string>
                {
                    StatusCode = StatusCode.OK,
                    Message = "Thêm loại gạo mới thành công",
                    Data = request.Name
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("[Create Rice Type]" + ex.InnerException.Message);
                throw;
            }
        }

     
    }
}
