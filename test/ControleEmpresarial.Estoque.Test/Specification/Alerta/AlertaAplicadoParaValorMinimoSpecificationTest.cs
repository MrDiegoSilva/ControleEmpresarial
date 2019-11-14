using ControleEmpresarial.Estoque.Domain.Entities.Enum;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Alerta;
using Moq;
using Xunit;

namespace ControleEmpresarial.Estoque.Test.Specification.Alerta
{
    public class AlertaAplicadoParaValorMinimoSpecificationTest
    {
        [Fact]
        public void Alerta_AlertaAplicadoParaValorMinimo_True()
        {
            var alerta = new Domain.Entities.Alerta("Winchester", 20, CondicoesDeAlerta.Definir_Limite_Para_Valor_Mínimo);
            var repo = new Mock<IProdutoRepository>();

            repo.Setup(r => r.TotalDeProdutosPorValorMinimo(alerta.ValorCondicao)).Returns(22);

            var alertaSpecification = new AlertaAplicadoParaValorMinimoSpecification(repo.Object);

            Assert.True(alertaSpecification.IsSatisfiedBy(alerta));
        }

        [Fact]
        public void Alerta_AlertaAplicadoParaValorMinimo_False()
        {
            var alerta = new Domain.Entities.Alerta("Winchester", 20, CondicoesDeAlerta.Definir_Limite_Para_Valor_Mínimo);
            var repo = new Mock<IProdutoRepository>();

            repo.Setup(r => r.TotalDeProdutosPorValorMinimo(alerta.ValorCondicao)).Returns(18);

            var alertaSpecification = new AlertaAplicadoParaValorMinimoSpecification(repo.Object);

            Assert.False(alertaSpecification.IsSatisfiedBy(alerta));
        }
    }
}