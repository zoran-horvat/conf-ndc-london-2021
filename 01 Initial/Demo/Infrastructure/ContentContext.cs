using Microsoft.EntityFrameworkCore.ChangeTracking;
using Demo.Logging;
using Demo.Models.Content;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Infrastructure
{
    public class ContentContext : DbContext
    {
        public DbSet<Product> Products => base.Set<Product>();
        private LogSink Logger { get; }

        public ContentContext(DbContextOptions<ContentContext> options, LogSink logger) : base(options)
        {
            this.Logger = logger;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.Logger.AppendMethodCalled();
            modelBuilder.ForProduct();
        }
    }
}
