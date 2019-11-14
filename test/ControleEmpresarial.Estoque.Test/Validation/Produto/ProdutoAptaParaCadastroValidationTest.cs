using System;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Validation.Produto;
using Moq;
using Xunit;

namespace ControleEmpresarial.Estoque.Test.Validation.Produto
{
    public class ProdutoAptaParaCadastroValidationTest
    {
        [Fact]
        public void Produto_AdicionarExistente_ValidarResultado()
        {
            var produto = Domain.Entities.Produto.Factory.NovoProduto("Oculos de Sol Marte CSA097463298C4", "CSA097463298C4", "12345678", "bicolor", 54, 12, 140, 4, 0);
            var repo = new Mock<IProdutoRepository>();

            repo.Setup(r => r.RetornarPorCodigo(produto.Codigo)).Returns(produto);

            var produtoValido = new ProdutoAptoParaCadastroValidation(repo.Object);

            Assert.False(produtoValido.Validate(produto).IsValid);
        }

        [Fact]
        public void Produto_AdicionarNova_ValidarResultado()
        {
            var produto = Domain.Entities.Produto.Factory.NovoProduto("Oculos de Sol Marte CSA097463298C4", "CSA097463298C4", "12345678", "bicolor", 54, 12, 140, 4, 0);
            var repo = new Mock<IProdutoRepository>();

            repo.Setup(r => r.RetornarPorCodigo(produto.Codigo)).Returns((Domain.Entities.Produto)null);

            var produtoValido = new ProdutoAptoParaCadastroValidation(repo.Object);

            Assert.True(produtoValido.Validate(produto).IsValid);
        }
    }
}