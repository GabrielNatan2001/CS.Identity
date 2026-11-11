using CS.Identity.Domain.Exceptions;

namespace CS.Identity.Domain.Usuario.ValueObjects;

public class SenhaVo
{
    public string Hash { get; private set; } = string.Empty;

    protected SenhaVo() { }
    private SenhaVo(string hash) => Hash = hash;

    public static SenhaVo Create(string plainPassword)
    {
        if (string.IsNullOrWhiteSpace(plainPassword) || plainPassword.Length < 8)
            throw new DomainException("Senha deve ter no mínimo 8 caracteres");

        return new SenhaVo(BCrypt.Net.BCrypt.HashPassword(plainPassword));
    }

    public static SenhaVo FromHash(string hash) => new(hash);

    public bool Verify(string plainPassword) => BCrypt.Net.BCrypt.Verify(plainPassword, Hash);
}
