using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LDI.BusinessLogic.Abstract;
using LDI.BusinessLogic.Concrete;
using LDI.DataAccess;
using LDI.DataAccess.Abstract;
using LDI.DataAccess.Concrete;
using LDI.Web.CustomFilters;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Elasticsearch;
using Serilog.Sinks.Elasticsearch;
using Swashbuckle.AspNetCore.Swagger;

namespace LDI.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            Log.Logger = new LoggerConfiguration()
                     .Enrich.FromLogContext()
                     .Enrich.WithProperty("Application", "LDI")
                     .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                     .MinimumLevel.Override("System", LogEventLevel.Warning)
                     .WriteTo.Elasticsearch(
                         new ElasticsearchSinkOptions(
                             new Uri("http://localhost:9200/"))
                         {
                             CustomFormatter = new ExceptionAsObjectJsonFormatter(renderMessage: true),
                             AutoRegisterTemplate = true,
                             TemplateName = "serilog-web-template",
                             IndexFormat = "ldi-web-{0:yyyy.MM.dd}"
                         })
                     .MinimumLevel.Verbose()
                     .CreateLogger();





            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.AddMvc().AddJsonOptions(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            services.AddHttpContextAccessor();
            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddDbContext<Context>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {

                serviceScope.ServiceProvider.GetService<Context>().Database.Migrate();

            }

                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                    app.UseHsts();
                }

            loggerFactory.AddSerilog();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });




        }
    }
}
