using System;
using ControleEmpresarial.Estoque.Domain.Entities;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Scopes;
using Moq;
using Xunit;

namespace ControleEmpresarial.Estoque.Test.Entities
{
    public class ProdutoTest
    {
        [Fact]
        public void Produto_ValidarProduto_True()
        {
            var produto = Produto.Factory.NovoProduto("Oculos de Sol Marte CSA097463298C4", "CSA097463298C4", "12345678", "bicolor", 54, 12, 140, 4, 0);
            var repo = new Mock<IProdutoRepository>();
            repo.Setup(r => r.RetornarPorCodigo(produto.Codigo)).Returns((Produto)null);
            Assert.True(produto.IsValid(repo.Object));
        }

        [Fact]
        public void Categoria_ValidarProduto_False()
        {
            var produto = Produto.Factory.NovoProduto("Oculos de Sol Marte CSA097463298C4", "CSA097463298C4", "12345678", "bicolor", 54, 12, 140, 4, 0);
            var repo = new Mock<IProdutoRepository>();
            repo.Setup(r => r.RetornarPorCodigo(produto.Codigo)).Returns(produto);
            Assert.False(produto.IsValid(repo.Object));
        }

        [Fact]
        public void Produto_VerificarCorValida_False()
        {
            var produto = Produto.Factory.NovoProduto("Oculos de Sol Marte CSA097463298C4", "CSA097463298C4", "12345678", "", 54, 12, 140, 4, 0);
            Assert.False(produto.ValidarCorEhValido(produto.Cor));
        }

        [Fact]
        public void Produto_VerificarTamanhoPonteValido_False()
        {
            var produto = Produto.Factory.NovoProduto("Oculos de Sol Marte CSA097463298C4", "CSA097463298C4", "12345678", "bicolor", 54, -1, 140, 4, 0);
            Assert.False(produto.ValidarTamanhoPonteEhValido(produto.TamanhoPonte));
        }

        [Fact]
        public void Produto_VerificarTamanhoAroValido_False()
        {
            var produto = Produto.Factory.NovoProduto("Oculos de Sol Marte CSA097463298C4", "CSA097463298C4", "12345678", "bicolor", -1, 12, 140, 4, 0);
            Assert.False(produto.ValidarTamanhoAroEhValido(produto.TamanhoPonte));
        }

        [Fact]
        public void Produto_VerificarComprimentoHasteValido_False()
        {
            var produto = Produto.Factory.NovoProduto("Oculos de Sol Marte CSA097463298C4", "CSA097463298C4", "12345678", "bicolor", 0, 12, -1, 4, 0);
            Assert.False(produto.ValidarComprimentoHasteEhValido(produto.ComprimentoHaste));
        }

        [Fact]
        public void Produto_VerificarCodigoValido_False()
        {
            var produto = Produto.Factory.NovoProduto("Oculos de Sol Marte CSA097463298C4", "CSA097463298C4", "", "bicolor", 0, 12, 0, 4, 0);
            Assert.False(produto.ValidarCodigoEhValido(produto.Codigo));
        }

        [Fact]
        public void Produto_VerificarModeloValido_False()
        {
            var produto = Produto.Factory.NovoProduto("Oculos de Sol Marte CSA097463298C4", "", "12345678", "bicolor", 0, 12, 0, 4, 0);
            Assert.False(produto.ValidarModeloEhValido(produto.Modelo));
        }

        [Fact]
        public void Produto_VerificarCurvaturaValido_False()
        {
            var produto = Produto.Factory.NovoProduto("Oculos de Sol Marte CSA097463298C4", "CSA097463298C4", "12345678", "bicolor", 50, 12, 140, -1, 0);
            Assert.False(produto.ValidarCurvaturaEhValido(produto.Curvatura));
        }
    }
}