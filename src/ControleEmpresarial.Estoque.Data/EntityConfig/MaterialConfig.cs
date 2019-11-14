using System.Data.Entity.ModelConfiguration;
using ControleEmpresarial.Estoque.Domain.Entities;

namespace ControleEmpresarial.Estoque.Data.EntityConfig
{
    public class MaterialConfig : EntityTypeConfiguration<Material>
    {
        public MaterialConfig()
        {
            HasKey(c => c.Id);

            Ignore(c => c.ResultadoValidacao);

            Property(c => c.Descricao)
                .HasColumnType("varchar")
                .HasMaxLength(120)
                .IsRequired();

            ToTable("Material");
        }
    }
}