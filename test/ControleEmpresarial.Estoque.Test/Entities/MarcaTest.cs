using ControleEmpresarial.Estoque.Domain.Entities;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Scopes;
using Moq;
using Xunit;

namespace ControleEmpresarial.Estoque.Test.Entities
{
    public class MarcaTest
    {
        [Fact]
        public void Marca_ValidarMarca_True()
        {
            var marca = new Marca("Winchester");
            var repo = new Mock<IMarcaRepository>();
            repo.Setup(r => r.RetornarPorDescricao(marca.Descricao)).Returns((Marca)null);
            Assert.True(marca.IsValid(repo.Object));
        }

        [Fact]
        public void Marca_ValidarMarca_False()
        {
            var marca = new Marca("Winchester");
            var repo = new Mock<IMarcaRepository>();
            repo.Setup(r => r.RetornarPorDescricao(marca.Descricao)).Returns(marca);
            Assert.False(marca.IsValid(repo.Object));
        }

        [Fact]
        public void Marca_VerificarDescriçãoValida_True()
        {
            var marca = new Marca("Winchester");
            Assert.True(marca.ValidarDescricaoEhValido(marca.Descricao));
        }

        [Fact]
        public void Marca_VerificarDescriçãoValida_False()
        {
            var marca = new Marca(null);
            Assert.False(marca.ValidarDescricaoEhValido(marca.Descricao));
        }
    }
}