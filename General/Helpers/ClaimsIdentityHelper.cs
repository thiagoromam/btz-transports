using System.Security.Claims;

namespace General.Helpers
{
    public static class ClaimsIdentityHelper
    {
        public static string GetValue(this ClaimsIdentity claims, string type)
        {
            return claims.FindFirst(type)?.Value;
        }

        public static void AddValue(this ClaimsIdentity claims, string type, object value)
        {
            claims.AddClaim(new Claim(type, value?.ToString() ?? ""));
        }
    }
}
