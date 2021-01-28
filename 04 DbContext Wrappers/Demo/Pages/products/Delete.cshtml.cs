using Demo.Infrastructure;
using Demo.Models.Content;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private IDbContext<Product> DbContext { get; }

        public DeleteModel(FullOwnershipContentContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public IActionResult OnPost(int productId)
        {
            if (this.DbContext.Find<Product>(productId) is Product toDelete)
            {
                this.DbContext.Remove(toDelete);
                this.DbContext.SaveChanges();
            }
            return RedirectToPage("/products/index");
        }
    }
}
