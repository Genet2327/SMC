using System.Security.Claims;

namespace SMC_UI
{
    public static class HtmlHelpers
    {
        public static bool IsLoggedIn(this ClaimsPrincipal user)
        {
            return user.Identity.IsAuthenticated && user.HasClaim(c => c.Type == ClaimTypes.Email);
        }

        public static string UserToke(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Sid)?.Value;
        }


    }
}
