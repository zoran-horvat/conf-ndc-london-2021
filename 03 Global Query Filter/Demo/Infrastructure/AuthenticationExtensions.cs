using Demo.Models.Authentication;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace Demo.Infrastructure
{
    public static class AuthenticationExtensions
    {
        public static UserRef GetAuthenticatedUser(this IHttpContextAccessor context) =>
            context.HttpContext.GetAuthenticatedUser();

        public static UserRef GetAuthenticatedUser(this HttpContext context) =>
            context.User.Claims
                .Where(claim => claim.Type == ClaimTypes.NameIdentifier)
                .Select(claim => new UserRef(claim.Value))
                .DefaultIfEmpty(UserRef.Empty)
                .First();

    }
}
