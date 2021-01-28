using Demo.Infrastructure;
using Demo.Logging;
using Demo.Models.Content;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private LogSink Logger { get; }
        private IContentReadContext DbContext { get; }
        public IEnumerable<IEnumerable<string>> LogLines { get; private set; } = Enumerable.Empty<IEnumerable<string>>();

        [BindProperty]
        public int ProductId { get; set; }
        public Product Product { get; private set; }

        public DetailsModel(LogSink logger, AssignedContentReadingContext dbContext)
        {
            this.Logger = logger;
            this.DbContext = dbContext;
        }

        public void OnGet(int productId)
        {
            this.Product = this.DbContext.Find<Product>(productId);
            this.LogLines = this.Logger.PrintableContent.Select(block => block.ToList()).ToList();
            this.Logger.Purge();
        }
    }
}
