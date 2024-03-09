
using Microsoft.OpenApi.Models;
using RoyalLibrary.Helpers;
using RoyalLibrary.IoC;
using Serilog;
using System.Reflection;

namespace RoyalLibrary
{
    public class Program
    {
        private const string RoyalLibraryCorsPolicyName = nameof(RoyalLibraryCorsPolicyName);

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
            builder.Services.AddRoyalLibraryDbContext(connectionString);

            builder.Services.RegisterInfra();
            builder.Services.RegisterRepositories();
            builder.Services.RegisterServices();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(RoyalLibraryCorsPolicyName, policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            });

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Royal Library API",
                    Description = "ASP.NET Core API for Royal Library"
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename), includeControllerXmlComments: true);
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.DefaultModelsExpandDepth(-1);
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Royal Library API v1");
                    options.RoutePrefix = string.Empty;
                });
            }

            app.UseCors(RoyalLibraryCorsPolicyName);

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    SeedDatabase.Initialize(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "");
                }
            }

            app.Run();
        }
    }
}