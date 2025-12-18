using Application.IUnitOfWork;
using Domain.Payload.Base;
using Domain.Share.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Command.Edit
{
    public class EditProductCommandHandle(IUnitOfWork.IUnitOfWork _unitOfWork,
                                          ILogger<EditProductCommandHandle> _logger) : IRequestHandler<EditProductCommand, ApiResponse<string>>
    {
        public async Task<ApiResponse<string>> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _unitOfWork.GetRepository<Domain.Entities.Products>()
                                               .GetByIdAsync(request.ProductId);

                if (product == null)
                {
                    return new ApiResponse<string>
                    {
                        StatusCode = StatusCode.BadRequest,
                        Message = "Product not found",
                        Data = null
                    };
                }

                var checkSku = await _unitOfWork.GetRepository<Domain.Entities.Products>()
                                                  .FindAsync(predicate: x => x.Sku == request.Sku && x.ID != request.ProductId);

                if (checkSku != null)
                {
                    return new ApiResponse<string>
                    {
                        StatusCode = StatusCode.Conflict,
                        Message = "Sku already exists",
                        Data = null
                    };
                }

                product.Sku = request.Sku;
                product.Name = request.Name;
                product.Description = request.Description;

                _unitOfWork.GetRepository<Domain.Entities.Products>().Update(product);
                await _unitOfWork.CommitAsync();

                return new ApiResponse<string>
                {
                    StatusCode = StatusCode.OK,
                    Message = "Product updated successfully",
                    Data = product.ID.ToString()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while editing product with ID {ProductId}", request.ProductId);
                throw new Exception(ex.ToString());
            }
        }
    }
}
