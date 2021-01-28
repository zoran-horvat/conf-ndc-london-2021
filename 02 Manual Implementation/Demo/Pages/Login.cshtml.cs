using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Demo.Infrastructure;
using Demo.Models.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Pages
{
    public class LoginModel : PageModel
    {
        private AuthenticationContext DbContext { get; }

        [BindProperty] public string UserName { get; set; } = string.Empty;

        public LoginModel(AuthenticationContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await this.SignOut();
            foreach (User user in this.DbContext.Users.Where(user => user.UserName == this.UserName))
            {
                await this.SignIn(user);
            }

            if (base.Request.Query.ContainsKey("ReturnUrl") && (string)base.Request.Query["ReturnUrl"] is string returnUri && Url.IsLocalUrl(returnUri))
                return Redirect(returnUri);
            else
                return RedirectToPage("Index");
        }

        private async Task SignIn(User user)
        {
            var claimsIdentity = new ClaimsIdentity(
                new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName), 
                    new Claim(ClaimTypes.NameIdentifier, user.Key),
                },
                CookieAuthenticationDefaults.AuthenticationScheme);
            
            await this.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));
        }

        private async Task SignOut() => 
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}
