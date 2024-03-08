
using Serilog;

namespace RoyalLibrary
{
    public class Program
    {
        private const string RoyalLibraryCorsPolicyName = nameof(RoyalLibraryCorsPolicyName);

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

            // Add services to the container.

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(RoyalLibraryCorsPolicyName, policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            });


            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
