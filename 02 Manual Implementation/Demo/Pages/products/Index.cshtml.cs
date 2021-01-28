using System.Collections.Generic;
using System.Linq;
using Demo.Infrastructure;
using Demo.Logging;
using Demo.Models.Content;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Pages.Products
{
    public class IndexModel : PageModel
    {
        private LogSink Logger { get; }
        private ContentContext DbContext { get; }
        public IEnumerable<IEnumerable<string>> LogLines { get; private set; } = Enumerable.Empty<IEnumerable<string>>();

        [BindProperty] public string NewProductName { get; set; } = string.Empty;
        public IEnumerable<Product> AllProducts { get; private set; } = Enumerable.Empty<Product>();

        public IndexModel(LogSink logger, ContentContext dbContext)
        {
            this.Logger = logger;
            this.DbContext = dbContext;
        }

        public void OnGet()
        {
            this.AllProducts = this.DbContext
                .Products
                .Where(product => product.OwnerKey == this.HttpContext.GetAuthenticatedUser().Value)
                .ToList();

            this.LogLines = this.Logger.PrintableContent.Select(block => block.ToList()).ToList();
            this.Logger.Purge();
        }
    }
}
