using BaseAPI.DI;
using BaseAPI.Middleware.JWTMidlleware;
using Domain.Config;
using Domain.KeyHandle;
using Domain.Payload.Base;
using Domain.Share.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Scalar.AspNetCore;
using System.Text;
using Microsoft.Extensions.Http;
using Microsoft.AspNetCore.OpenApi;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSingleton<IApiKeyValidator, ApiKeyValidator>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();


#region  HTTP Configuration
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});

builder.Services.AddHttpContextAccessor();
var httpContextAccessor = builder.Services.BuildServiceProvider()
    .GetRequiredService<IHttpContextAccessor>();
#endregion

#region JWT & SCALAR Configuration

var jwtSection = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(jwtSection);
builder.Services.AddSingleton<IAuthorizationPolicyProvider, DynamicPermissionPolicyProvider>();
builder.Services.AddScoped<IAuthorizationHandler, AnyPolicyHandler>();

var jwtSettings = jwtSection.Get<JwtSettings>();
JWTService.Configure(jwtSettings, httpContextAccessor);

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
        };

        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                context.NoResult();
                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/json";
                return context.Response.WriteAsync("{\"error\":\"Token không hợp lệ hoặc đã hết hạn.\"}");
            },
            OnChallenge = context =>
            {
                context.HandleResponse();
                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/json";
                return context.Response.WriteAsync(JsonConvert.SerializeObject(new ApiResponse<string>
                {
                    StatusCode = StatusCode.Unauthorized,
                    Message = "Bạn chưa đăng nhập hoặc token không hợp lệ.",
                    Data = null
                }));
            },
            OnForbidden = context =>
            {
                context.Response.StatusCode = 403;
                context.Response.ContentType = "application/json";
                var response = new ApiResponse<string>
                {
                    StatusCode = StatusCode.Forbidden,
                    Message = "Bạn không có quyền truy cập vào tài nguyên này.",
                    Data = null
                };
                return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
            }
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

builder.Services.AddOpenApi("v1", options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Info = new OpenApiInfo
        {
            Title = "BaseAPI",
            Version = "v1",
            Description = "API dùng JWT và test bằng Scalar"
        };

        document.Components ??= new OpenApiComponents();
        document.Components.SecuritySchemes["Bearer"] = new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Description = "Nhập 'Bearer {JWT_TOKEN}'"
        };

        document.SecurityRequirements.Add(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new List<string>()
            }
        });

        return Task.CompletedTask;
    });
});

#endregion

DependencyInjection.Register(builder.Services, builder.Configuration, new HttpContextAccessor(), builder.Environment);
var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference(options =>
{
    options.Theme = ScalarTheme.Saturn;
});


app.MapGet("/ping", (string? name) =>
{
    return Results.Ok($"✅ Server hoạt động tốt! Xin chào {name ?? "bạn"}");
})
.WithOpenApi(operation =>
{
    operation.Summary = "Ping server (dùng query param)";
    operation.Parameters[0].Description = "Tên người dùng";
    return operation;
});

app.MapGet("/secure/{id:int}", [Authorize] (int id) =>
{
    return Results.Ok(new
    {
        message = "🎯 Đã truy cập API có route param!",
        id,
        time = DateTime.Now
    });
})
.WithOpenApi(operation =>
{
    operation.Summary = "API bảo vệ (route param + JWT)";
    return operation;
});

app.MapPost("/secure/json", [Authorize] (UserInfo request) =>
{
    return Results.Ok(new
    {
        message = "📦 Nhận JSON body thành công!",
        data = request
    });
})
.WithOpenApi(operation =>
{
    operation.Summary = "POST JSON body (JWT)";
    return operation;
});

app.MapPost("/secure/form", [Authorize] async (HttpRequest req) =>
{
    var form = await req.ReadFormAsync();
    var name = form["name"];
    var file = form.Files["file"];

    return Results.Ok(new
    {
        message = "📤 Nhận form-data thành công!",
        name,
        fileName = file?.FileName,
        fileSize = file?.Length
    });
})
.Accepts<IFormFile>("multipart/form-data")
.WithOpenApi(operation =>
{
    operation.Summary = "POST Form-data upload (JWT)";
    return operation;
});

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

public record UserInfo(string Name, int Age, string Email);

