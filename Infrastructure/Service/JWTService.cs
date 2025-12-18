using Domain.Config;
using Domain.Entities;
using Google.Apis.Drive.v3.Data;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
#pragma warning disable

public static class JWTService
{
    private static JwtSettings _jwtSettings;
    private static IHttpContextAccessor _httpContextAccessor;
    public static void Configure(JwtSettings settings, IHttpContextAccessor httpContextAccessor)
    {
        _jwtSettings = settings;
        _httpContextAccessor = httpContextAccessor;
    }

    public static string GenerateToken(User user)
    {
        var httpContext = _httpContextAccessor.HttpContext;

        string ip = "Unknown";
        string fingerprint = "Unknown";

        if (httpContext != null)
        {
            ip = httpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (!string.IsNullOrEmpty(ip))
            {
                ip = ip.Split(',')[0].Trim();
            }
            else
            {
                ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
            }

            fingerprint = GenerateFingerprint(httpContext);
        }
        //var claims = new List<Claim>
        //{
        //    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        //    new Claim(ClaimTypes.Name, user.Username),
        //    new Claim("ip", ip),
        //    new Claim("fp", fingerprint)
        //};

        //if (user.UserTypeNavigation != null)
        //{
        //    claims.Add(new Claim(ClaimTypes.Role, user.UserTypeNavigation.Name));
        //}

        //if (user?.Employee?.Department?.DepartmentPermission != null &&
        //    user.Employee.Department.DepartmentPermission.Any())
        //{
        //    var allowedPermissions = user.Employee.Department.DepartmentPermission
        //        .Select(dp => $"{NormalizePermissionKey(dp.Permissions.Module)}.{dp.Permissions.Action.ToUpperInvariant()}")
        //        .ToList();

        //    if (allowedPermissions.Any())
        //    {
        //        claims.Add(new Claim("permission_count", allowedPermissions.Count.ToString()));
        //        claims.Add(new Claim("permissions", string.Join(",", allowedPermissions)));
        //    }
        //}

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            //claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpireMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public static string GenerateFingerprint(HttpContext context)
    {
        var ua = context.Request.Headers["User-Agent"].ToString();
        var lang = context.Request.Headers["Accept-Language"].ToString();
        var platform = context.Request.Headers["Sec-CH-UA-Platform"].ToString();

        var raw = $"{ua}|{lang}|{platform}";
        using var sha = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(raw);

        return Convert.ToBase64String(sha.ComputeHash(bytes));
    }

    private static string NormalizePermissionKey(string module)
    {
        if (string.IsNullOrWhiteSpace(module))
            return string.Empty;

        var noDiacritics = RemoveDiacritics(module);
        var noSpaces = new string(noDiacritics
            .Where(c => !char.IsWhiteSpace(c))
            .ToArray());

        return noSpaces.ToUpperInvariant();
    }
    private static string RemoveDiacritics(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return text;

        var normalized = text.Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder();

        foreach (var ch in normalized)
        {
            var unicodeCategory = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(ch);
            if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark)
            {
                sb.Append(ch);
            }
        }

        return sb.ToString().Normalize(NormalizationForm.FormC)
                 .Replace("Đ", "D")
                 .Replace("đ", "d");
    }

    public static string? GetUserId(ClaimsPrincipal user)
    {
        return user.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
            ?? user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }

    public static string? GetUser()
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

    }

    public static string GenerateActivationToken(string email)
    {
        var claims = new[]
        {
        new Claim(JwtRegisteredClaimNames.Email, email),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpireMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
