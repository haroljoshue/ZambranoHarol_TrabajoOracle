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
                case "MySql":
                    builder.Services.AddDbContext<AppDbContext>(options =>
                        options.UseMySql(
                            builder.Configuration.GetConnectionString("AppDbContextMySql"),
                            new MySqlServerVersion(new Version(12, 10, 0))
                        )
                        .LogTo(Console.WriteLine, LogLevel.Information)
                        .EnableSensitiveDataLogging());
                    break;
                case "SqlServer":
                    builder.Services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContextSqlServer"))
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