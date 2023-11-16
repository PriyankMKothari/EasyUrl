using Microsoft.EntityFrameworkCore;
using UrlShortener.Application;
using UrlShortener.Persistent;
using UrlShortener.Persistent.DbContexts;
using UrlShortener.Persistent.Entities;
using UrlShortener.Persistent.Repositories;
using UrlShortener.Services;
using UrlShortener.Services.Mappers;

namespace UrlShortener.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webApplicationBuilder = WebApplication.CreateBuilder(args);

            // Build Services
            // Add CORS
            webApplicationBuilder.Services.AddCors(policy =>
            {
                policy.AddPolicy("CorsPolicy", options =>
                {
                    options
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            // Controllers
            webApplicationBuilder.Services.AddControllers();

            // API Explorer
            webApplicationBuilder.Services.AddEndpointsApiExplorer();
            webApplicationBuilder.Services.AddSwaggerGen();

            // API Versioning
            //webApplicationBuilder.Services.AddApiVersioning(options =>
            //{
            //    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
            //    options.ReportApiVersions = true;
            //    options.AssumeDefaultVersionWhenUnspecified = true;
            //    options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(), new HeaderApiVersionReader("x-api-version"));
            //});

            //webApplicationBuilder.Services.AddVersionedApiExplorer(options =>
            //{
            //    options.GroupNameFormat = "'v'VVV";
            //    options.SubstituteApiVersionInUrl = true;
            //});

            // Register DBContext
            webApplicationBuilder.Services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlite(webApplicationBuilder.Configuration.GetConnectionString("UrlShortenerConnectionString"));
            });
            webApplicationBuilder.Services.AddScoped<DatabaseContext>();

            // Services
            webApplicationBuilder.Services
                .AddScoped<IUrlShortenerService, UrlShortenerService>()
                .AddScoped<IDatabaseService, DatabaseService>()
                .AddScoped<ICodeService, CodeService>()
                .AddScoped<ITagRepository, TagRepository>();

            // Register AutoMappers
            webApplicationBuilder.Services.AddAutoMapper(typeof(BusinessModelMappingProfile));

            // Build Web Application
            var webApplication = webApplicationBuilder.Build();

            // Configure the HTTP request pipeline.
            if (webApplication.Environment.IsDevelopment())
            {
                webApplication.UseSwagger();
                webApplication.UseSwaggerUI();
            }

            webApplication.UseHttpsRedirection();
            webApplication.UseAuthorization();
            webApplication.UseCors("CorsPolicy");

            webApplication.MapControllerRoute("Default",
                "{controller}/{action}/{type}",
                new { controller = "UrlShortener", action = "Get" });

            webApplication.MapControllers();

            // Run Web Application
            webApplication.Run();
        }
    }
}