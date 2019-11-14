using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Validation.Categoria;
using Moq;
using Xunit;

namespace ControleEmpresarial.Estoque.Test.Validation.Categoria
{
    public class CategoriaAptaParaCadastroValidationTest
    {
        [Fact]
        public void Categoria_AdicionarExistente_ValidarResultado()
        {
            var categoria = new Domain.Entities.Categoria("armacao");
            var repo = new Mock<ICategoriaRepository>();

            repo.Setup(r => r.RetornarPorDescricao(categoria.Descricao)).Returns(categoria);

            var marcaValida = new CategoriaAptaParaCadastroValidation(repo.Object);

            Assert.False(marcaValida.Validate(categoria).IsValid);
        }

        [Fact]
        public void Categoria_AdicionarNova_ValidarResultado()
        {
            var categoria = new Domain.Entities.Categoria("armacao");
            var repo = new Mock<ICategoriaRepository>();

            repo.Setup(r => r.RetornarPorDescricao(categoria.Descricao)).Returns((Domain.Entities.Categoria)null);

            var marcaValida = new CategoriaAptaParaCadastroValidation(repo.Object);

            Assert.True(marcaValida.Validate(categoria).IsValid);
        }
    }
}