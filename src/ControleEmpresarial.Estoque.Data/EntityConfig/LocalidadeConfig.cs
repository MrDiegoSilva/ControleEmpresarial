using System.Data.Entity.ModelConfiguration;
using ControleEmpresarial.Estoque.Domain.Entities;

namespace ControleEmpresarial.Estoque.Data.EntityConfig
{
    public class LocalidadeConfig : EntityTypeConfiguration<Localidade>
    {
        public LocalidadeConfig()
        {
            HasKey(l => l.Id);

            Property(l => l.Descricao)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();

            Property(l => l.Endereco)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();

            Ignore(l => l.ResultadoValidacao);

            ToTable("Localidade");

        }
    }
}