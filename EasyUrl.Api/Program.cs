using Microsoft.EntityFrameworkCore;
using EasyUrl.Application;
using EasyUrl.Persistent.DbContexts;
using EasyUrl.Persistent.Repositories;
using EasyUrl.Services;
using EasyUrl.Services.Mappers;

namespace EasyUrl.Api;

// easyurl.io
// easyurl.core
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
            var connectionString = webApplicationBuilder.Configuration.GetConnectionString("EasyUrlConnectionString"); 
            options.UseSqlite(connectionString);
                
        });
        webApplicationBuilder.Services.AddScoped<DatabaseContext>();

        // Services
        webApplicationBuilder.Services
            .AddScoped<IUrlShortener, UrlShortener>()
            .AddScoped<IDatabaseService, DatabaseService>()
            .AddScoped<ICodeService, CodeService>()
            .AddScoped<IEasyUrlRepository, EasyUrlRepository>();

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