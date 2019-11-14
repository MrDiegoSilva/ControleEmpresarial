using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Validation.Marca;
using Moq;
using Xunit;

namespace ControleEmpresarial.Estoque.Test.Validation.Marca
{
    public class MarcaAptaParaCadastroValidationTest
    {
        [Fact]
        public void Marca_AdicionarExistente_ValidarResultado()
        {
            var marca = new Domain.Entities.Marca("Winchester");
            var repo = new Mock<IMarcaRepository>();

            repo.Setup(r => r.RetornarPorDescricao(marca.Descricao)).Returns(marca);

            var marcaValida = new MarcaAptaParaCadastroValidation(repo.Object);

            Assert.False(marcaValida.Validate(marca).IsValid);
        }

        [Fact]
        public void Marca_AdicionarNova_ValidarResultado()
        {
            var marca = new Domain.Entities.Marca("Winchester");
            var repo = new Mock<IMarcaRepository>();

            repo.Setup(r => r.RetornarPorDescricao(marca.Descricao)).Returns((Domain.Entities.Marca) null);

            var marcaValida = new MarcaAptaParaCadastroValidation(repo.Object);

            Assert.True(marcaValida.Validate(marca).IsValid);
        }
    }
}