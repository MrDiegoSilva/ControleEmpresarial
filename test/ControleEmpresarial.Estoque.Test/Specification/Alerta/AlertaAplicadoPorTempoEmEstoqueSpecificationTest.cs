using ControleEmpresarial.Estoque.Domain.Entities.Enum;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Alerta;
using Moq;
using Xunit;

namespace ControleEmpresarial.Estoque.Test.Specification.Alerta
{
    public class AlertaAplicadoPorTempoEmEstoqueSpecificationTest
    {
        [Fact]
        public void Alerta_AlertaAplicadoPorTempoEmEstoque_True()
        {
            var alerta = new Domain.Entities.Alerta("Winchester", 20, CondicoesDeAlerta.Definir_Limite_Para_Valor_Mínimo);
            var repo = new Mock<IProdutoRepository>();

            repo.Setup(r => r.TotalDeProdutosPorTempoEmEstoque(alerta.ValorCondicao)).Returns(22);

            var alertaSpecification = new AlertaAplicadoPorTempoEmEstoqueSpecification(repo.Object);

            Assert.True(alertaSpecification.IsSatisfiedBy(alerta));
        }

        [Fact]
        public void Alerta_AlertaAplicadoPorTempoEmEstoque_False()
        {
            var alerta = new Domain.Entities.Alerta("Winchester", 20, CondicoesDeAlerta.Definir_Limite_Para_Valor_Mínimo);
            var repo = new Mock<IProdutoRepository>();

            repo.Setup(r => r.TotalDeProdutosPorTempoEmEstoque(alerta.ValorCondicao)).Returns(18);

            var alertaSpecification = new AlertaAplicadoPorTempoEmEstoqueSpecification(repo.Object);

            Assert.False(alertaSpecification.IsSatisfiedBy(alerta));
        }
    }
}