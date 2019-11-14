using System.Data.Entity.ModelConfiguration;
using ControleEmpresarial.Estoque.Domain.Entities;

namespace ControleEmpresarial.Estoque.Data.EntityConfig
{
    public class AlertaConfig : EntityTypeConfiguration<Alerta>
    {
        public AlertaConfig()
        {
            HasKey(a => a.Id);

            Property(a => a.Descricao)
                .HasColumnType("varchar")
                .HasMaxLength(120)
                .IsRequired();

            Ignore(a => a.ResultadoValidacao);

            ToTable("Alerta");
        }
    }
}