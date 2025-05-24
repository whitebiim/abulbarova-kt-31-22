using abulbarovakt_31_22.Database;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;


using abulbarovakt_31_22.ServiceExtensions;

using abulbarovakt_31_22.Middlewares;





var builder = WebApplication.CreateBuilder(args);
var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
// Add services to the container.
try

{
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();


    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<TeacherDbContext>(option =>
   option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
 );

    builder.Services.AddServices();


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseMiddleware<ExceptionHandlerMiddleware>();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "STOP");
}
finally
{
    LogManager.Shutdown();
}