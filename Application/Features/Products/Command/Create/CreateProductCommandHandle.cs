using Application.IUnitOfWork;
using Domain.Payload.Base;
using Domain.Share.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Features.Products.Command.Create
{
    public class CreateProductCommandHandle(IUnitOfWork _unitOfWork) : IRequestHandler<CreateProductCommand, ApiResponse<string>>
    {
        public async Task<ApiResponse<string>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _unitOfWork.GetRepository<Domain.Entities.Products>()
                                               .FindAsync(predicate: x => x.Sku.Equals(request.SKU));
                if (product == null)
                {
                    return new ApiResponse<string>
                    {

                        StatusCode = StatusCode.Conflict,
                        Message = "Mã sản phẩm đã tồn tại",
                        Data = null
                    };
                }

                var newProduct = new Domain.Entities.Products
                {
                    ID = Guid.NewGuid(),
                    CreatedBy = null,
                    IsDeleted = false,
                    ModifiedDate = null,
                    CreatedDate = null,
                    DeletedDate = null,
                    UpdateBy = null,
                    Name = request.Name,
                    Sku = request.SKU,
                    Description = request.Description
                };

                await _unitOfWork.GetRepository<Domain.Entities.Products>().AddAsync(newProduct);
                await _unitOfWork.CommitAsync();

                return new ApiResponse<string>
                {
                    StatusCode = StatusCode.OK,
                    Message = "Tạo sản phẩm thành công",
                    Data = newProduct.ID.ToString()
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
