using Demo.Infrastructure;
using Demo.Logging;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace Demo
{
    public class Startup
    {
        private string ConnectionString => @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SecurityDemo";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages(options =>
                options.Conventions.AuthorizePage("/Products/Index"));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Login";
                    options.LogoutPath = "/Logout";
                });

            services.AddSingleton(new ShopLoggerConfiguration(LogLevel.Debug));
            services.AddSingleton<LogSink>();

            ILoggerFactory LoggerFactoryFactory(IServiceProvider svc) =>
                LoggerFactory.Create(builder => builder
                    .AddFilter(DbLoggerCategory.Name, LogLevel.Debug)
                    .AddShopLogger(svc.GetService<ShopLoggerConfiguration>(), svc.GetService<LogSink>));

            void ConfigureDbOptions(IServiceProvider svc, DbContextOptionsBuilder options) =>
                options.UseSqlServer(this.ConnectionString).UseLoggerFactory(LoggerFactoryFactory(svc));

            services.AddDbContext<EntireContext>(ConfigureDbOptions);
            services.AddDbContext<AuthenticationContext>(ConfigureDbOptions);
            services.AddDbContext<ContentContext>(ConfigureDbOptions);

            services.AddHttpContextAccessor();
            services.AddSingleton<TenancyProvider>();

            services.AddScoped<AssignedContentReadingContext>();
            services.AddScoped<FullOwnershipContentContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
