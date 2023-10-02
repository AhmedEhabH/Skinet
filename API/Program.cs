using API.Extensions;
using API.Middleware;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

app.UseStatusCodePagesWithReExecute("/errors/{0}");


app.UseSwagger();
app.UseSwaggerUI();


app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scoop = app.Services.CreateScope();
var services = scoop.ServiceProvider;
var logger = services.GetRequiredService<ILogger<Program>>();
var context = services.GetRequiredService<StoreContext>();
try
{
    await context.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context, logger);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occured during migration");
}

app.Run();

// dotnet run --launch-profile https
