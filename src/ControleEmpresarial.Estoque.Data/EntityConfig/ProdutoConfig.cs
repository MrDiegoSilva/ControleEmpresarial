using System.Data.Entity.ModelConfiguration;
using ControleEmpresarial.Estoque.Domain.Entities;

namespace ControleEmpresarial.Estoque.Data.EntityConfig
{
    public class ProdutoConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfig()
        {
            HasKey(p => p.Id);

            Ignore(p => p.ResultadoValidacao);

            Property(p => p.Codigo)
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();

            Property(p => p.Descricao)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();

            Property(p => p.ComprimentoHaste)
                .HasColumnType("int")
                .IsRequired();

            Property(p => p.TamanhoAro)
                .HasColumnType("int")
                .IsRequired();

            Property(p => p.TamanhoPonte)
                .HasColumnType("int")
                .IsRequired();

            Property(p => p.Cor)
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();

            Property(p => p.AlturaLente)
                .HasColumnType("int");

            Property(p => p.Modelo)
                .HasColumnType("varchar")
                .HasMaxLength(250);

            ToTable("Produtos");

            HasRequired(p => p.Marca)
                .WithMany(m => m.ProdutosCollection)
                .HasForeignKey(p => p.MarcaId);

            HasRequired(p => p.Material)
                .WithMany(m => m.ProdutosCollection)
                .HasForeignKey(p => p.MaterialId);

            HasRequired(p => p.Categoria)
                .WithMany(c => c.ProdutosCollection)
                .HasForeignKey(p => p.CategoriaId);

            HasRequired(p => p.Sessao)
                .WithMany(c => c.ProdutosCollection)
                .HasForeignKey(p => p.SessaoId);

        }
    }
}