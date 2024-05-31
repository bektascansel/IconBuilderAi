using MextFullstackSaaS.Infrastructure;
using MextFullstackSaaS.WebApi;
using MextFullstackSaaS.WebApi.Filters;
using MextFullstackSaaS.Application;

using Microsoft.AspNetCore.Mvc;
using Serilog;


Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("C:\\Users\\CANSEL BEKTAS\\Desktop\\log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();


try
{
    Log.Information("Starting web application");
    
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddSerilog();

    // Add services to the container.

    builder.Services.AddControllers(opt =>
    {
        opt.Filters.Add<GlobalExceptionFilter>();
    });


    builder.Services.Configure<ApiBehaviorOptions>(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddWebServices(builder.Configuration);

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
catch (Exception e)
{
    Log.Fatal(e, "Application terminated unexpectedly");

}
finally
{
    Log.CloseAndFlush();
}



