using System;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Produto;
using Moq;
using Xunit;

namespace ControleEmpresarial.Estoque.Test.Specification.Produto
{
    public class ProdutoDeveSerUnicaSpecificationTest
    {
        [Fact]
        public void Produto_DeveSerUnica_False()
        {
            var produto = Domain.Entities.Produto.Factory.NovoProduto("Oculos de Sol Marte CSA097463298C4", "CSA097463298C4", "12345678", "bicolor", 54, 12, 140, 4, 0);
            var repo = new Mock<IProdutoRepository>();

            repo.Setup(r => r.RetornarPorCodigo(produto.Codigo)).Returns(produto);

            var produtoSpecification = new ProdutoDeveSerUnicoSpecification(repo.Object);

            Assert.False(produtoSpecification.IsSatisfiedBy(produto));
        }

        [Fact]
        public void Produto_DeveSerUnica_True()
        {
            var produto = Domain.Entities.Produto.Factory.NovoProduto("Oculos de Sol Marte CSA097463298C4", "CSA097463298C4", "12345678", "bicolor", 54, 12, 140, 4, 0);
            var repo = new Mock<IProdutoRepository>();

            repo.Setup(r => r.RetornarPorCodigo(produto.Codigo)).Returns((Domain.Entities.Produto)null);

            var produtoSpecification = new ProdutoDeveSerUnicoSpecification(repo.Object);

            Assert.True(produtoSpecification.IsSatisfiedBy(produto));
        }
    }
}