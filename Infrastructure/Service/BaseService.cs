using Application.IService;
using Application.IUnitOfWork;
using Application.Payload.Request.Products;
using Domain.Entities;
using Domain.Payload.Base;
using Domain.Share.Common;
using Infrastructure.Context;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class BaseService(IUnitOfWork<DBContext> _unitOfWork) : IBaseService
    {
        public async Task<ApiResponse<string>> CreateProduct(CreateProductRequest request)
        {
            var checkSku = await _unitOfWork.GetRepository<Products>()
                                            .FindAsync(predicate: x => x.Sku.Equals(request.Sku));
            if (checkSku.Count() > 0)
            {
                return new ApiResponse<string>
                {
                    StatusCode = StatusCode.Conflict,
                    Message = "SKU đã tồn tại",
                    Data = null
                };
            }

            var newProduct = new Products
            {
                ID = Guid.NewGuid(),
                CreatedBy = null,
                CreatedDate = DateTime.Now,
                DeletedDate = null,
                ModifiedDate = null,
                IsDeleted = false,
                Name = request.Name,
                Sku = request.Sku,
                UpdateBy = null,
                Description = request.Description
            };

            await _unitOfWork.GetRepository<Products>().AddAsync(newProduct);
            await _unitOfWork.CommitAsync();

            return new ApiResponse<string>
            {
                StatusCode = StatusCode.OK,
                Message = string.Empty,
                Data = null
            };
        }
    }
}
