using CS.Identity.Application.Abstractions.Security;
using CS.Identity.Application.Usuario.Dtos;
using CS.Identity.Domain.Exceptions;
using CS.Identity.Domain.Usuario.Interfaces;

namespace CS.Identity.Application.Usuario.Services;

public class AutenticarUsuarioService
{
    private readonly IUsuarioRepository _repo;
    private readonly ITokenProvider _tokenProvider;

    public AutenticarUsuarioService(IUsuarioRepository repo, ITokenProvider tokenProvider)
    {
        _repo = repo;
        _tokenProvider = tokenProvider;
    }

    public async Task<AuthResponseDto> ExecutarAsync(AutenticarUsuarioDto dto, CancellationToken ct = default)
    {
        var usuario = await _repo.GetByEmailAsync(dto.Email, ct)
            ?? throw new DomainException("Credenciais inválidas");

        if (!usuario.Senha.Verify(dto.Senha))
            throw new DomainException("Credenciais inválidas");

        var token = _tokenProvider.GerarToken(usuario);
        return new AuthResponseDto(token, usuario.Email.Value, usuario.Role.ToString(), usuario.Id);
    }
}
