using API.Extensions;
using API.Middleware;
using Core.Entities.Identity;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityService(builder.Configuration);
builder.Services.AddSwaggerDocumentation();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

app.UseStatusCodePagesWithReExecute("/errors/{0}");


app.UseSwaggerDocumentation();


app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Content")
    ),
    RequestPath = "/content"
});


app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapFallbackToController("Index", "Fallback");

using var scoop = app.Services.CreateScope();
var services = scoop.ServiceProvider;

var logger = services.GetRequiredService<ILogger<Program>>();
var context = services.GetRequiredService<StoreContext>();

var userManager = services.GetRequiredService<UserManager<AppUser>>();
var identityContext = services.GetRequiredService<AppIdentityDbContext>();
try
{
    await context.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context, logger);

    await identityContext.Database.MigrateAsync();
    await AppIdentityDbContextSeed.SeedUserAsync(userManager);

}
catch (Exception ex)
{
    logger.LogError(ex, "An error occured during migration");
}

app.Run();

// dotnet run --launch-profile https
