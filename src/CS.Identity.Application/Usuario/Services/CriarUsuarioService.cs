using CS.Identity.Application.Usuario.Dtos;
using CS.Identity.Domain.Exceptions;
using CS.Identity.Domain.Usuario.Entities;
using CS.Identity.Domain.Usuario.Interfaces;

namespace CS.Identity.Application.Usuario.Services;

public class CriarUsuarioService
{
    private readonly IUsuarioRepository _repo;

    public CriarUsuarioService(IUsuarioRepository repo) => _repo = repo;

    public async Task<Guid> ExecutarAsync(CriarUsuarioDto dto, CancellationToken ct = default)
    {
        if (await _repo.EmailExistsAsync(dto.Email, ct))
            throw new DomainException("Email já cadastrado");

        var usuario = UsuarioEntity.CriarDoador(dto.NomeCompleto, dto.Email, dto.Cpf, dto.Senha);
        await _repo.AddAsync(usuario, ct);
        await _repo.SaveChangesAsync(ct);
        return usuario.Id;
    }
}
