using Application.IService;
using Application.IUnitOfWork;
using Application.Payload.Response.Auth;
using Domain.Payload.Base;
using Domain.Share.Common;
using Domain.Share.Util;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable
namespace Application.Features.Auth.Command.Login
{
    public class LoginCommandHandle(IUnitOfWork.IUnitOfWork _unitOfWork,
                                    ILogger<LoginCommand> _logger,
                                    IJWTService _jwtService)
        : IRequestHandler<LoginCommand, ApiResponse<LoginResponse>>
    {
        /*
            1. Tìm user trong database theo UserName
            2. Nếu không tìm thấy, trả về lỗi BadRequest
            3. Kiểm tra mật khẩu (hash) có khớp không, nếu không khớp trả về lỗi
            4. Nếu đăng nhập thành công, tạo JWT token
            5. Trả về thông tin user và token
        */
        async Task<ApiResponse<LoginResponse>> IRequestHandler<LoginCommand, ApiResponse<LoginResponse>>.Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var checkUserName = await _unitOfWork
                    .GetRepository<Domain.Entities.User>()
                    .SingleOrDefaultAsync(
                        predicate: x => x.UserName.Equals(request.UserName),
                        include: u => u.Include(x => x.Employees));

                if (checkUserName == null)
                {
                    return new ApiResponse<LoginResponse>
                    {
                        StatusCode = StatusCode.BadRequest,
                        Message = "Tên đăng nhập không tồn tại"
                    };
                }

                if (!PasswordUtil.HashPassword(request.Password)
                    .Equals(checkUserName.Password))
                {
                    return new ApiResponse<LoginResponse>
                    {
                        StatusCode = StatusCode.BadRequest,
                        Message = "Mật khẩu không đúng"
                    };
                }

                var token = _jwtService.GenerateToken(checkUserName);

                return new ApiResponse<LoginResponse>
                {
                    StatusCode = StatusCode.OK,
                    Message = "Đăng nhập thành công",
                    Data = new LoginResponse
                    {
                        UserName = checkUserName.UserName,
                        Avatar = checkUserName.Employees?.Select(e => e.Avatar).FirstOrDefault(),
                        FullName = checkUserName.Employees?.Select(e => e.FullName).FirstOrDefault(),
                        Token = token
                    }
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[Login Feature]");
                throw;
            }
        }
    }
}
