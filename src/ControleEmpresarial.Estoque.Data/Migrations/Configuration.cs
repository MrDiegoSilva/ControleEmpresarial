using ControleEmpresarial.Estoque.Domain.Entities;

namespace ControleEmpresarial.Estoque.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ControleEmpresarial.Estoque.Data.Context.EstoqueContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ControleEmpresarial.Estoque.Data.Context.EstoqueContext";
        }

        protected override void Seed(ControleEmpresarial.Estoque.Data.Context.EstoqueContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //context.Marca.AddOrUpdate(
            //  new Marca("Andrea Corsini"),
            //  new Marca("Armatti"),
            //  new Marca("Caffe"),
            //  new Marca("Christies"),
            //  new Marca("Clot�"),
            //  new Marca("Kristal"),
            //  new Marca("Lookids"),
            //  new Marca("Luciana Gim"),
            //  new Marca("Opera Chic"),
            //  new Marca("People"),
            //  new Marca("Pierre Cardin"),
            //  new Marca("Winchester"),
            //  new Marca("Speed"),
            //  new Marca("Vizu")
            //);

            //context.Material.AddOrUpdate(
            //    new Material("Acetato"),
            //    new Material("Metal"),
            //    new Material("Titanium"),
            //    new Material("Injetados"),
            //    new Material("Madeira"),
            //    new Material("Pl�stico"),
            //    new Material("Ultem"),
            //    new Material("Tartaruga"),
            //    new Material("Alum�nio")
            //);

            //context.Categoria.AddOrUpdate(
            //    new Categoria("Arma��o")
            //);
            //
        }
    }
}
