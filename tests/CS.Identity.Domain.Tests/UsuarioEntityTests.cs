using CS.Identity.Domain.Common;
using CS.Identity.Domain.Exceptions;
using CS.Identity.Domain.Usuario.Entities;

namespace CS.Identity.Domain.Tests;

public class UsuarioEntityTests
{
    [Fact]
    public void Cadastro_publico_deve_criar_doador()
    {
        var u = UsuarioEntity.CriarDoador("Fulano", "fulano@ong.com", "39053344705", "Teste@123");
        Assert.Equal(ERole.Doador, u.Role);
    }

    [Fact]
    public void Deve_rejeitar_nome_vazio()
    {
        Assert.Throws<DomainException>(() =>
            UsuarioEntity.CriarDoador(" ", "a@b.com", "39053344705", "Teste@123"));
    }
}
