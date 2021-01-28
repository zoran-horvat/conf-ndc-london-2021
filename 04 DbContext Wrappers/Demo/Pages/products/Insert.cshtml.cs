using Demo.Infrastructure;
using Demo.Models.Content;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Pages.Products
{
    public class InsertModel : PageModel
    {
        private IWriteDbContext<Product> DbContext { get; }

        public InsertModel(FullOwnershipContentContext dbContext)
        {
            this.DbContext = dbContext;
        }

        [BindProperty] public string NewProductName { get; set; } = string.Empty;

        public IActionResult OnPost()
        {
            if (!string.IsNullOrWhiteSpace(this.NewProductName))
            {
                this.DbContext.Add(new Product(0, this.NewProductName, base.HttpContext.GetAuthenticatedUser()));
                this.DbContext.SaveChanges();
            }
            return RedirectToPage("./index");
        }
    }
}
