using ControleEmpresarial.Estoque.Domain.Entities.Enum;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Validation.Alerta;
using Moq;
using Xunit;

namespace ControleEmpresarial.Estoque.Test.Validation.Alerta
{
    public class AlertaAplicadoParaTodosOsProdutosValidationTest
    {
        [Fact]
        public void Alerta_AlertaAplicadoParaTodosOsProdutos_True()
        {
            var alerta = new Domain.Entities.Alerta("Winchester", 20, CondicoesDeAlerta.Definir_Limite_Para_Todo_Estoque);
            var repo = new Mock<IProdutoRepository>();

            repo.Setup(r => r.TotalDeProdutos()).Returns(22);

            var alertaSpecification = new AlertaAplicadoParaTodosOsProdutosValidation(repo.Object);

            Assert.True(alertaSpecification.Validate(alerta).IsValid);
        }

        [Fact]
        public void Alerta_AlertaAplicadoParaTodosOsProdutos_False()
        {
            var alerta = new Domain.Entities.Alerta("Winchester", 20, CondicoesDeAlerta.Definir_Limite_Para_Todo_Estoque);
            var repo = new Mock<IProdutoRepository>();

            repo.Setup(r => r.TotalDeProdutos()).Returns(18);

            var alertaSpecification = new AlertaAplicadoParaTodosOsProdutosValidation(repo.Object);

            Assert.False(alertaSpecification.Validate(alerta).IsValid);
        }
    }
}