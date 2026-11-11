using CS.Identity.Domain.Base;
using CS.Identity.Domain.Common;
using CS.Identity.Domain.Exceptions;
using CS.Identity.Domain.Usuario.ValueObjects;

namespace CS.Identity.Domain.Usuario.Entities;

public class UsuarioEntity : BaseEntity
{
    public string NomeCompleto { get; private set; } = string.Empty;
    public EmailVo Email { get; private set; } = null!;
    public CpfVo Cpf { get; private set; } = null!;
    public SenhaVo Senha { get; private set; } = null!;
    public ERole Role { get; private set; }

    protected UsuarioEntity() { }

    private UsuarioEntity(string nomeCompleto, EmailVo email, CpfVo cpf, SenhaVo senha, ERole role)
    {
        NomeCompleto = nomeCompleto;
        Email = email;
        Cpf = cpf;
        Senha = senha;
        Role = role;
    }

    public static UsuarioEntity CriarDoador(string nomeCompleto, string email, string cpf, string senha)
    {
        if (string.IsNullOrWhiteSpace(nomeCompleto))
            throw new DomainException("Nome completo é obrigatório");

        return new UsuarioEntity(
            nomeCompleto.Trim(),
            EmailVo.Create(email),
            CpfVo.Create(cpf),
            SenhaVo.Create(senha),
            ERole.Doador);
    }

    public static UsuarioEntity CriarGestor(string nomeCompleto, string email, string cpf, string senha)
    {
        if (string.IsNullOrWhiteSpace(nomeCompleto))
            throw new DomainException("Nome completo é obrigatório");

        return new UsuarioEntity(
            nomeCompleto.Trim(),
            EmailVo.Create(email),
            CpfVo.Create(cpf),
            SenhaVo.Create(senha),
            ERole.GestorONG);
    }
}
