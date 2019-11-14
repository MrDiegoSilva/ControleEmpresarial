using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ControleEmpresarial.Estoque.Data.EntityConfig;
using ControleEmpresarial.Estoque.Domain.Entities;

namespace ControleEmpresarial.Estoque.Data.Context
{
    public class EstoqueContext : DbContext
    {
        public EstoqueContext() : base("ControleEmpresarialContext")
        {
            
        }

        public DbSet<Marca> Marca { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Alerta> Alerta { get; set; }
        public DbSet<Localidade> Localidade { get; set; }
        public DbSet<Sessao> Sessao { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new MarcaConfig());
            modelBuilder.Configurations.Add(new CategoriaConfig());
            modelBuilder.Configurations.Add(new MaterialConfig());
            modelBuilder.Configurations.Add(new ProdutoConfig());
            modelBuilder.Configurations.Add(new AlertaConfig());
            modelBuilder.Configurations.Add(new LocalidadeConfig());
            modelBuilder.Configurations.Add(new SessaoConfig());
        }
    }
}