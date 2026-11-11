using System.Text.RegularExpressions;
using CS.Identity.Domain.Exceptions;

namespace CS.Identity.Domain.Usuario.ValueObjects;

public class EmailVo
{
    public string Value { get; private set; } = string.Empty;

    protected EmailVo() { }
    private EmailVo(string value) => Value = value;

    public static EmailVo Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new DomainException("Email é obrigatório");

        email = email.Trim().ToLowerInvariant();
        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new DomainException("Email inválido");

        return new EmailVo(email);
    }
}
