using CRUD.Extensions;
using Databases.DbContexts;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;
using System.Text.Json.Serialization;

namespace CRUD;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Logging.ClearProviders();
        builder.Logging.AddNLog();

        var services = builder.Services;

        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });
        services.AddSwaggerGen(options =>
        {
            options.EnableAnnotations();
        });
        services.AddServices();
        services.AddAutoMapper(typeof(Program));
        services.AddDbContext<GamesDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GamesDb")));
        services.AddRouting(routeOptions => routeOptions.LowercaseUrls = true);

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.MapControllers();
        app.UseMiddlewares();

        app.Run();
    }
}