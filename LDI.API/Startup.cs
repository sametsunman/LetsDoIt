using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LDI.BusinessLogic.Abstract;
using LDI.BusinessLogic.Concrete;
using LDI.DataAccess;
using LDI.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Elasticsearch;
using Serilog.Sinks.Elasticsearch;
using Swashbuckle.AspNetCore.Swagger;

namespace LDI.API
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
                 TemplateName = "serilog-api-template",
                 IndexFormat = "ldi-api-{0:yyyy.MM.dd}"
             })
         .MinimumLevel.Verbose()
         .CreateLogger();


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "asd",
                    ValidAudience = "asd",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("letsdoit-asnus-com"))
                };
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<Context>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Let's Do It Swagger Eklentisi",
                    Description = "ASP.NET Core Web API",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Samet Sunman", Email = "contact@asnus.com", Url = "www.asnus.com" }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            loggerFactory.AddSerilog();

            app.UseCors(
                option => option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
                );

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Idemy Project Web API Test");
            });
        }
    }
}
