using Demo.Models.Authentication;
using Microsoft.AspNetCore.Http;

namespace Demo.Infrastructure
{
    public class TenancyProvider
    {
        private IHttpContextAccessor Context { get; }

        public TenancyProvider(IHttpContextAccessor context)
        {
            this.Context = context;
        }

        public UserRef AuthenticatedUser => this.Context.GetAuthenticatedUser();
    }
}
