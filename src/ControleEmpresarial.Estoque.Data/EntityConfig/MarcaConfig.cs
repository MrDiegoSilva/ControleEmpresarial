using System.Data.Entity.ModelConfiguration;
using ControleEmpresarial.Estoque.Domain.Entities;

namespace ControleEmpresarial.Estoque.Data.EntityConfig
{
    public class MarcaConfig : EntityTypeConfiguration<Marca>
    {
        public MarcaConfig()
        {
            HasKey(m => m.Id);

            Ignore(m => m.ResultadoValidacao);

            Property(c => c.Descricao)
                .HasColumnType("varchar")
                .HasMaxLength(120)
                .IsRequired();

            ToTable("Marcas");
        }   
    }
}