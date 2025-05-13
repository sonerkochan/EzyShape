using EzyShape.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using System.Security.Claims;

namespace EzyShape.Middlewares
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, UserManager<User> userManager)
        {
            if (context.User.Identity?.IsAuthenticated ?? false)
            {
                var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId != null)
                {
                    var user = await userManager.FindByIdAsync(userId);
                    if (user != null && !string.IsNullOrEmpty(user.PreferredLanguage))
                    {
                        var culture = new CultureInfo(user.PreferredLanguage);
                        CultureInfo.CurrentCulture = culture;
                        CultureInfo.CurrentUICulture = culture;
                    }
                }
            }

            await _next(context);
        }
    }

}
