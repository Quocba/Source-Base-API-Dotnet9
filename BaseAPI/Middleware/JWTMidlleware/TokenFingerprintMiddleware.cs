namespace API.Middleware.JWTMidlleware
{
    public class TokenFingerprintMiddleware
    {
        private readonly RequestDelegate _next;
        public TokenFingerprintMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity?.IsAuthenticated != true)
            {
                await _next(context);
                return;

            }

            var tokenFp = context.User.FindFirst(c => c.Type == "fp")?.Value;
            var currentFp = JWTService.GenerateFingerprint(context);
            if (!string.IsNullOrEmpty(tokenFp) &&
                           !string.Equals(tokenFp, currentFp, StringComparison.Ordinal))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Device fingerprint mismatch");
                return;
            }

            await _next(context);
        }
    }
}
