using CS.Identity.Domain.Exceptions;

namespace CS.Identity.Domain.Usuario.ValueObjects;

public class CpfVo
{
    public string Value { get; private set; } = string.Empty;

    protected CpfVo() { }
    private CpfVo(string value) => Value = value;

    public static CpfVo Create(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            throw new DomainException("CPF é obrigatório");

        var digits = new string(cpf.Where(char.IsDigit).ToArray());
        if (digits.Length != 11)
            throw new DomainException("CPF deve conter 11 dígitos");

        if (digits.Distinct().Count() == 1)
            throw new DomainException("CPF inválido");

        if (!ValidarDigitos(digits))
            throw new DomainException("CPF inválido");

        return new CpfVo(digits);
    }

    private static bool ValidarDigitos(string cpf)
    {
        int[] nums = cpf.Select(c => c - '0').ToArray();
        var sum1 = 0;
        for (int i = 0; i < 9; i++) sum1 += nums[i] * (10 - i);
        var d1 = sum1 % 11;
        d1 = d1 < 2 ? 0 : 11 - d1;
        if (nums[9] != d1) return false;

        var sum2 = 0;
        for (int i = 0; i < 10; i++) sum2 += nums[i] * (11 - i);
        var d2 = sum2 % 11;
        d2 = d2 < 2 ? 0 : 11 - d2;
        return nums[10] == d2;
    }
}
