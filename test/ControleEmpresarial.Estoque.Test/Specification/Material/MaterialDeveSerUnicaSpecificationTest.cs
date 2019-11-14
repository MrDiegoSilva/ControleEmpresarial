using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Material;
using Moq;
using Xunit;

namespace ControleEmpresarial.Estoque.Test.Specification.Material
{
    public class MaterialDeveSerUnicaSpecificationTest
    {
        [Fact]
        public void Material_DeveSerUnica_False()
        {
            var material = new Domain.Entities.Material("plástico");
            var repo = new Mock<IMaterialRepository>();

            repo.Setup(r => r.RetornarPorDescricao(material.Descricao)).Returns(material);

            var materialSpecification = new MaterialDeveSerUnicaSpecification(repo.Object);

            Assert.False(materialSpecification.IsSatisfiedBy(material));
        }

        [Fact]
        public void Material_DeveSerUnica_True()
        {
            var material = new Domain.Entities.Material("plástico");
            var repo = new Mock<IMaterialRepository>();

            repo.Setup(r => r.RetornarPorDescricao(material.Descricao)).Returns((Domain.Entities.Material)null);

            var materialSpecification = new MaterialDeveSerUnicaSpecification(repo.Object);

            Assert.True(materialSpecification.IsSatisfiedBy(material));
        }
    }
}