using CS.Identity.Domain.Usuario.Entities;
using CS.Identity.Domain.Usuario.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CS.Identity.Infrastructure.Data.Mappings;

public class UsuarioMapping : IEntityTypeConfiguration<UsuarioEntity>
{
    public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
    {
        builder.ToTable("usuarios");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.NomeCompleto).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Role).HasConversion<string>().HasMaxLength(50).IsRequired();
        builder.Property(x => x.CriadoEm).IsRequired();

        builder.OwnsOne(x => x.Email, email =>
        {
            email.Property(e => e.Value).HasColumnName("email").HasMaxLength(200).IsRequired();
            email.HasIndex(e => e.Value).IsUnique();
        });

        builder.OwnsOne(x => x.Cpf, cpf =>
        {
            cpf.Property(c => c.Value).HasColumnName("cpf").HasMaxLength(11).IsRequired();
        });

        builder.OwnsOne(x => x.Senha, senha =>
        {
            senha.Property(s => s.Hash).HasColumnName("senha_hash").HasMaxLength(200).IsRequired();
        });
    }
}
