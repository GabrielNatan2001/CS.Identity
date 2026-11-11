using CS.Identity.API.Middlewares;
using CS.Identity.API.Services;
using CS.Identity.Application;
using CS.Identity.Application.Abstractions.Security;
using CS.Identity.Domain.Usuario.Entities;
using CS.Identity.Infrastructure;
using CS.Identity.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddHealthChecksInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddScoped<ITokenProvider, JwtTokenProvider>();

var app = builder.Build();
await SeedAsync(app);

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpMetrics();
app.UseMiddleware<ExceptionMiddleware>();
app.MapHealthChecks("/health");
app.MapMetrics();
app.MapControllers();
app.Run();

static async Task SeedAsync(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.MigrateAsync();

    if (!await db.Usuarios.AnyAsync(u => u.Email.Value == "gestor@ong.com"))
    {
        await db.Usuarios.AddAsync(UsuarioEntity.CriarGestor(
            "Gestor ONG", "gestor@ong.com", "52998224725", "Teste@123"));
    }

    if (!await db.Usuarios.AnyAsync(u => u.Email.Value == "doador@ong.com"))
    {
        await db.Usuarios.AddAsync(UsuarioEntity.CriarDoador(
            "Doador Demo", "doador@ong.com", "39053344705", "Teste@123"));
    }

    await db.SaveChangesAsync();
}
