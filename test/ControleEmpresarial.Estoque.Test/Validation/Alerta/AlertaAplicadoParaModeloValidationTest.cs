using ControleEmpresarial.Estoque.Domain.Entities.Enum;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Validation.Alerta;
using Moq;
using Xunit;

namespace ControleEmpresarial.Estoque.Test.Validation.Alerta
{
    public class AlertaAplicadoParaModeloValidationTest
    {
        [Fact]
        public void Alerta_AlertaAplicadoParaModelo_True()
        {
            var alerta = new Domain.Entities.Alerta("Winchester", 20, CondicoesDeAlerta.Definir_Limite_Por_Modelo);
            var repo = new Mock<IProdutoRepository>();

            repo.Setup(r => r.TotalDeProdutosPorModelo(alerta.ValorCondicao)).Returns(22);

            var alertaSpecification = new AlertaAplicadoParaModeloValidation(repo.Object);

            Assert.True(alertaSpecification.Validate(alerta).IsValid);
        }

        [Fact]
        public void Alerta_AlertaAplicadoParaModelo_False()
        {
            var alerta = new Domain.Entities.Alerta("Winchester", 20, CondicoesDeAlerta.Definir_Limite_Por_Modelo);
            var repo = new Mock<IProdutoRepository>();

            repo.Setup(r => r.TotalDeProdutosPorModelo(alerta.ValorCondicao)).Returns(18);

            var alertaSpecification = new AlertaAplicadoParaModeloValidation(repo.Object);

            Assert.False(alertaSpecification.Validate(alerta).IsValid);
        }
    }
}