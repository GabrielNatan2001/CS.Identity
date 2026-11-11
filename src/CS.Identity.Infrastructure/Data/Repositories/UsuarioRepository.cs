using CS.Identity.Domain.Usuario.Entities;
using CS.Identity.Domain.Usuario.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CS.Identity.Infrastructure.Data.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _db;

    public UsuarioRepository(AppDbContext db) => _db = db;

    public async Task AddAsync(UsuarioEntity usuario, CancellationToken ct = default)
        => await _db.Usuarios.AddAsync(usuario, ct);

    public async Task<bool> EmailExistsAsync(string email, CancellationToken ct = default)
    {
        var normalized = email.Trim().ToLowerInvariant();
        return await _db.Usuarios.AnyAsync(u => u.Email.Value == normalized, ct);
    }

    public async Task<UsuarioEntity?> GetByEmailAsync(string email, CancellationToken ct = default)
    {
        var normalized = email.Trim().ToLowerInvariant();
        return await _db.Usuarios.FirstOrDefaultAsync(u => u.Email.Value == normalized, ct);
    }

    public Task SaveChangesAsync(CancellationToken ct = default)
        => _db.SaveChangesAsync(ct);
}
