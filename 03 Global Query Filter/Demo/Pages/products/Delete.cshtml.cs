using Demo.Infrastructure;
using Demo.Models.Content;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private ContentContext DbContext { get; }

        public DeleteModel(ContentContext dbContext)
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
