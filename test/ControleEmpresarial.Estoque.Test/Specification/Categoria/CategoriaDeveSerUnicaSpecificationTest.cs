using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Categoria;
using Moq;
using Xunit;

namespace ControleEmpresarial.Estoque.Test.Specification.Categoria
{
    public class CategoriaDeveSerUnicaSpecificationTest
    {
        [Fact]
        public void Categoria_DeveSerUnica_False()
        {
            var categoria = new Domain.Entities.Categoria("Armacao");
            var repo = new Mock<ICategoriaRepository>();

            repo.Setup(r => r.RetornarPorDescricao(categoria.Descricao)).Returns(categoria);

            var marcaSpecification = new CategoriaDeveSerUnicaSpecification(repo.Object);

            Assert.False(marcaSpecification.IsSatisfiedBy(categoria));
        }

        [Fact]
        public void Categoria_DeveSerUnica_True()
        {
            var categoria = new Domain.Entities.Categoria("armacao");
            var repo = new Mock<ICategoriaRepository>();

            repo.Setup(r => r.RetornarPorDescricao(categoria.Descricao)).Returns((Domain.Entities.Categoria)null);

            var marcaSpecification = new CategoriaDeveSerUnicaSpecification(repo.Object);

            Assert.True(marcaSpecification.IsSatisfiedBy(categoria));
        }
    }
}