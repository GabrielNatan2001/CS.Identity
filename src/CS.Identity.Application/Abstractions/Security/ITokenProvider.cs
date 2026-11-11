using CS.Identity.Domain.Usuario.Entities;

namespace CS.Identity.Application.Abstractions.Security;

public interface ITokenProvider
{
    string GerarToken(UsuarioEntity usuario);
}
