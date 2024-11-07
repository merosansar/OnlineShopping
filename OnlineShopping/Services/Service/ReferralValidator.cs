using Microsoft.AspNetCore.Identity;

namespace OnlineShopping.Web.Services.Service
{
    public class ReferralValidator(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, SignInManager<IdentityUser> signInManager)
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly IConfiguration _configuration = configuration;
        private readonly SignInManager<IdentityUser> _signInManager = signInManager;

        public async Task<bool> ValidateReferralAsync()
        {
            // Get the login URL from appsettings.json
            _ = _configuration["LoginURL"] ?? "";

            var httpContext = _httpContextAccessor.HttpContext;

            // Check if UrlReferrer is null
            if (httpContext!= null)
            {
                if (httpContext.Request.Headers.Referer.ToString() == string.Empty)
                {
                    // Sign out the user
                    await _signInManager.SignOutAsync();

                    // Clear the session
                    httpContext.Session.Clear();

                    return true;
                }
            }

            // Check if the referrer is from a different host
            if (httpContext != null)
            {
                var requestHost = httpContext.Request.Host.Host;
                var referrerHost = new Uri(httpContext.Request.Headers.Referer.ToString()).Host;

                if (requestHost != referrerHost)
                {
                    // Sign out the user
                    await _signInManager.SignOutAsync();

                    // Clear the session
                    httpContext.Session.Clear();

                    return true;
                }
            }
           

            return false;
        }
    }
}
