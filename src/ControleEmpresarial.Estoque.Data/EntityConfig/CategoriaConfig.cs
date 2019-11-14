using System.Data.Entity.ModelConfiguration;
using ControleEmpresarial.Estoque.Domain.Entities;

namespace ControleEmpresarial.Estoque.Data.EntityConfig
{
    public class CategoriaConfig : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfig()
        {
            HasKey(c => c.Id);

            Ignore(c => c.ResultadoValidacao);

            Property(c => c.Descricao)
                .HasColumnType("varchar")
                .HasMaxLength(120)
                .IsRequired();

            ToTable("Categoria");
        }
    }
}