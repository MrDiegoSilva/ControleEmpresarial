using ControleEmpresarial.Estoque.Domain.Entities;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Scopes;
using Moq;
using Xunit;

namespace ControleEmpresarial.Estoque.Test.Entities
{
    public class CategoriaTest
    {
        [Fact]
        public void Categoria_ValidarCategoria_True()
        {
            var categoria = new Categoria("Winchester");
            var repo = new Mock<ICategoriaRepository>();
            repo.Setup(r => r.RetornarPorDescricao(categoria.Descricao)).Returns((Categoria)null);
            Assert.True(categoria.IsValid(repo.Object));
        }

        [Fact]
        public void Categoria_ValidarCategoria_False()
        {
            var categoria = new Categoria("Winchester");
            var repo = new Mock<ICategoriaRepository>();
            repo.Setup(r => r.RetornarPorDescricao(categoria.Descricao)).Returns(categoria);
            Assert.False(categoria.IsValid(repo.Object));
        }

        [Fact]
        public void Categoria_VerificarDescriçãoValida_True()
        {
            var categoria = new Categoria("armacao");
            Assert.True(categoria.ValidarDescricaoEhValido(categoria.Descricao));
        }

        [Fact]
        public void Categoria_VerificarDescriçãoValida_False()
        {
            var categoria = new Categoria(null);
            Assert.False(categoria.ValidarDescricaoEhValido(categoria.Descricao));
        }
    }
}