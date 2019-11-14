using ControleEmpresarial.Estoque.Domain.Entities.Enum;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Alerta;
using Moq;
using Xunit;

namespace ControleEmpresarial.Estoque.Test.Specification.Alerta
{
    public class AlertaAplicadoParaModeloSpecificationTest
    {
        [Fact]
        public void Alerta_AlertaAplicadoParaModelo_True()
        {
            var alerta = new Domain.Entities.Alerta("Winchester", 20, CondicoesDeAlerta.Definir_Limite_Por_Modelo);
            var repo = new Mock<IProdutoRepository>();

            repo.Setup(r => r.TotalDeProdutosPorModelo(alerta.ValorCondicao)).Returns(22);

            var alertaSpecification = new AlertaAplicadoParaModeloSpecification(repo.Object);

            Assert.True(alertaSpecification.IsSatisfiedBy(alerta));
        }

        [Fact]
        public void Alerta_AlertaAplicadoParaModelo_False()
        {
            var alerta = new Domain.Entities.Alerta("Winchester", 20, CondicoesDeAlerta.Definir_Limite_Por_Modelo);
            var repo = new Mock<IProdutoRepository>();

            repo.Setup(r => r.TotalDeProdutosPorModelo(alerta.ValorCondicao)).Returns(18);

            var alertaSpecification = new AlertaAplicadoParaModeloSpecification(repo.Object);

            Assert.False(alertaSpecification.IsSatisfiedBy(alerta));
        }
    }
}