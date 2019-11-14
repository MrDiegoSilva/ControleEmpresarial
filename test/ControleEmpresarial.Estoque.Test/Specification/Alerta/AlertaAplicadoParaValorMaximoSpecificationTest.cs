using ControleEmpresarial.Estoque.Domain.Entities.Enum;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Alerta;
using Moq;
using Xunit;

namespace ControleEmpresarial.Estoque.Test.Specification.Alerta
{
    public class AlertaAplicadoParaValorMaximoSpecificationTest
    {
        [Fact]
        public void Alerta_AlertaAplicadoParaValorMaximo_True()
        {
            var alerta = new Domain.Entities.Alerta("Winchester", 20, CondicoesDeAlerta.Definir_Limite_Para_Valor_Máximo);
            var repo = new Mock<IProdutoRepository>();

            repo.Setup(r => r.TotalDeProdutosPorValorMaximo(alerta.ValorCondicao)).Returns(22);

            var alertaSpecification = new AlertaAplicadoParaValorMaximoSpecification(repo.Object);

            Assert.True(alertaSpecification.IsSatisfiedBy(alerta));
        }

        [Fact]
        public void Alerta_AlertaAplicadoParaValorMaximo_False()
        {
            var alerta = new Domain.Entities.Alerta("Winchester", 20, CondicoesDeAlerta.Definir_Limite_Para_Valor_Máximo);
            var repo = new Mock<IProdutoRepository>();

            repo.Setup(r => r.TotalDeProdutosPorValorMaximo(alerta.ValorCondicao)).Returns(18);

            var alertaSpecification = new AlertaAplicadoParaValorMaximoSpecification(repo.Object);

            Assert.False(alertaSpecification.IsSatisfiedBy(alerta));
        }
    }
}