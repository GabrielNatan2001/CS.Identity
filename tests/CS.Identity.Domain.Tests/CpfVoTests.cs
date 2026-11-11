using CS.Identity.Domain.Exceptions;
using CS.Identity.Domain.Usuario.ValueObjects;

namespace CS.Identity.Domain.Tests;

public class CpfVoTests
{
    [Fact]
    public void Deve_aceitar_cpf_valido()
    {
        var cpf = CpfVo.Create("529.982.247-25");
        Assert.Equal("52998224725", cpf.Value);
    }

    [Fact]
    public void Deve_rejeitar_cpf_invalido()
    {
        Assert.Throws<DomainException>(() => CpfVo.Create("11111111111"));
    }

    [Fact]
    public void Deve_rejeitar_cpf_com_digitos_errados()
    {
        Assert.Throws<DomainException>(() => CpfVo.Create("52998224726"));
    }
}
