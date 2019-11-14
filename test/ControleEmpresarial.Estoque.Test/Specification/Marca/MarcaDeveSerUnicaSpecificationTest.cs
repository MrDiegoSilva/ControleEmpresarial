using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Marca;
using Moq;
using Xunit;

namespace ControleEmpresarial.Estoque.Test.Specification.Marca
{
    public class MarcaDeveSerUnicaSpecificationTest
    {
        [Fact]
        public void Marca_DeveSerUnica_False()
        {
            var marca = new Domain.Entities.Marca("Winchester");
            var repo = new Mock<IMarcaRepository>();

            repo.Setup(r => r.RetornarPorDescricao(marca.Descricao)).Returns(marca);

            var marcaSpecification = new MarcaDeveSerUnicaSpecification(repo.Object);

            Assert.False(marcaSpecification.IsSatisfiedBy(marca));
        }

        [Fact]
        public void Marca_DeveSerUnica_True()
        {
            var marca = new Domain.Entities.Marca("Winchester");
            var repo = new Mock<IMarcaRepository>();

            repo.Setup(r => r.RetornarPorDescricao(marca.Descricao)).Returns((Domain.Entities.Marca)null);

            var marcaSpecification = new MarcaDeveSerUnicaSpecification(repo.Object);

            Assert.True(marcaSpecification.IsSatisfiedBy(marca));
        }
    }
}