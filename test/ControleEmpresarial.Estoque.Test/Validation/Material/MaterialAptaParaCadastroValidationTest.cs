using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Validation.Material;
using Moq;
using Xunit;

namespace ControleEmpresarial.Estoque.Test.Validation.Material
{
    public class MaterialAptaParaCadastroValidationTest
    {
        [Fact]
        public void Material_AdicionarExistente_ValidarResultado()
        {
            var maaterial = new Domain.Entities.Material("plástico");
            var repo = new Mock<IMaterialRepository>();

            repo.Setup(r => r.RetornarPorDescricao(maaterial.Descricao)).Returns(maaterial);

            var materialValida = new MaterialAptaParaCadastroValidation(repo.Object);

            Assert.False(materialValida.Validate(maaterial).IsValid);
        }

        [Fact]
        public void Material_AdicionarNova_ValidarResultado()
        {
            var material = new Domain.Entities.Material("plástico");
            var repo = new Mock<IMaterialRepository>();

            repo.Setup(r => r.RetornarPorDescricao(material.Descricao)).Returns((Domain.Entities.Material)null);

            var materialValida = new MaterialAptaParaCadastroValidation(repo.Object);

            Assert.True(materialValida.Validate(material).IsValid);
        }
    }
}