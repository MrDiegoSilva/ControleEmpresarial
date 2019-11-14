namespace ControleEmpresarial.Estoque.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teste : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alerta",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 120, unicode: false),
                        Quantidade = c.Int(nullable: false),
                        ValorCondicao = c.String(),
                        Disparado = c.Boolean(nullable: false),
                        CondicaoDeAlerta = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 120, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MarcaId = c.Guid(nullable: false),
                        MaterialId = c.Guid(nullable: false),
                        CategoriaId = c.Guid(nullable: false),
                        SessaoId = c.Guid(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 250, unicode: false),
                        Modelo = c.String(maxLength: 250, unicode: false),
                        Codigo = c.String(nullable: false, maxLength: 150, unicode: false),
                        Cor = c.String(nullable: false, maxLength: 150, unicode: false),
                        TamanhoAro = c.Int(nullable: false),
                        TamanhoPonte = c.Int(nullable: false),
                        ComprimentoHaste = c.Int(nullable: false),
                        Curvatura = c.Int(nullable: false),
                        AlturaLente = c.Int(nullable: false),
                        ValorCompra = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValorVenda = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataEntrada = c.DateTime(nullable: false),
                        DataMovimentacao = c.DateTime(nullable: false),
                        EmEstoque = c.Boolean(nullable: false),
                        StatusDoProduto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId)
                .ForeignKey("dbo.Marcas", t => t.MarcaId)
                .ForeignKey("dbo.Material", t => t.MaterialId)
                .ForeignKey("dbo.Sessao", t => t.SessaoId)
                .Index(t => t.MarcaId)
                .Index(t => t.MaterialId)
                .Index(t => t.CategoriaId)
                .Index(t => t.SessaoId);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 120, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Material",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 120, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sessao",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LocalidadeId = c.Guid(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Localidade", t => t.LocalidadeId)
                .Index(t => t.LocalidadeId);
            
            CreateTable(
                "dbo.Localidade",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 250, unicode: false),
                        Endereco = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "SessaoId", "dbo.Sessao");
            DropForeignKey("dbo.Sessao", "LocalidadeId", "dbo.Localidade");
            DropForeignKey("dbo.Produtos", "MaterialId", "dbo.Material");
            DropForeignKey("dbo.Produtos", "MarcaId", "dbo.Marcas");
            DropForeignKey("dbo.Produtos", "CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Sessao", new[] { "LocalidadeId" });
            DropIndex("dbo.Produtos", new[] { "SessaoId" });
            DropIndex("dbo.Produtos", new[] { "CategoriaId" });
            DropIndex("dbo.Produtos", new[] { "MaterialId" });
            DropIndex("dbo.Produtos", new[] { "MarcaId" });
            DropTable("dbo.Localidade");
            DropTable("dbo.Sessao");
            DropTable("dbo.Material");
            DropTable("dbo.Marcas");
            DropTable("dbo.Produtos");
            DropTable("dbo.Categoria");
            DropTable("dbo.Alerta");
        }
    }
}
