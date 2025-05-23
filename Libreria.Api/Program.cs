using Libreria.Api.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Libreria.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Obtener el proveedor de base de datos desde la configuración
            var provider = builder.Configuration.GetValue<string>("DatabaseProvider");

            switch (provider)
            {
                case "Oracle":
                    builder.Services.AddDbContext<AppDbContext>(options =>
                        options.UseOracle(
                            builder.Configuration.GetConnectionString("AppDbContextOracle"))
                        .LogTo(Console.WriteLine, LogLevel.Information)
                        .EnableSensitiveDataLogging());
                    break;
                default:
                    throw new Exception("Proveedor de base de datos no válido.");
            }

            builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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