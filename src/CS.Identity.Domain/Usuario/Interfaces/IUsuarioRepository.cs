using CS.Identity.Domain.Usuario.Entities;

namespace CS.Identity.Domain.Usuario.Interfaces;

public interface IUsuarioRepository
{
    Task AddAsync(UsuarioEntity usuario, CancellationToken ct = default);
    Task<UsuarioEntity?> GetByEmailAsync(string email, CancellationToken ct = default);
    Task<bool> EmailExistsAsync(string email, CancellationToken ct = default);
    Task SaveChangesAsync(CancellationToken ct = default);
}
