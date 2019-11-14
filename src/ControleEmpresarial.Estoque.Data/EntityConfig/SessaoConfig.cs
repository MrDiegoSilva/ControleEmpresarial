using System.Data.Entity.ModelConfiguration;
using ControleEmpresarial.Estoque.Domain.Entities;

namespace ControleEmpresarial.Estoque.Data.EntityConfig
{
    public class SessaoConfig : EntityTypeConfiguration<Sessao>
    {
        public SessaoConfig()
        {
            HasKey(s => s.Id);

            Property(l => l.Descricao)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();

            Ignore(l => l.ResultadoValidacao);

            ToTable("Sessao");

            HasRequired(s => s.Localidade)
                .WithMany(l => l.SessoesCollection)
                .HasForeignKey(s => s.LocalidadeId);
        }
    }
}