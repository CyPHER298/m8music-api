using M8MusicAPI.Data;
using M8MusicAPI.Repository;
using M8MusicAPI.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace M8MusicAPI;

public class Program
{
    public static void Main(String[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var swaggerConfig = builder
            .Configuration
            .GetSection("Swagger")
            .Get<SwaggerConfig>();

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = swaggerConfig.Title,
                    Version = "v1",
                    Description = swaggerConfig.Description,
                    Contact = swaggerConfig.Contact
                });

                swagger.EnableAnnotations();

                foreach (var server in swaggerConfig.Servers)
                {
                    swagger.AddServer(new OpenApiServer
                    {
                        Url = server.Url,
                        Description = server.Name
                    });
                }
            }
        );

        builder.Services.AddDbContext<AppDbContext>(opt =>
            opt.UseOracle(builder.Configuration.GetConnectionString("M8MusicAPI"))
        );

        // builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
        // builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
        
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddOpenApi();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(ui =>
            {
                ui.SwaggerEndpoint("/swagger/v1/swagger.json", "M8MusicAPI v1");
                ui.RoutePrefix = string.Empty;
            });
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}