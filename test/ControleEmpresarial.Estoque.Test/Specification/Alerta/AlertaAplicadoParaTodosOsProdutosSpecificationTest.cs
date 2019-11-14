using ControleEmpresarial.Estoque.Domain.Entities.Enum;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Alerta;
using Moq;
using Xunit;

namespace ControleEmpresarial.Estoque.Test.Specification.Alerta
{
    public class AlertaAplicadoParaTodosOsProdutosSpecificationTest
    {
        [Fact]
        public void Alerta_AlertaAplicadoParaTodosOsProdutos_True()
        {
            var alerta = new Domain.Entities.Alerta("Winchester", 20, CondicoesDeAlerta.Definir_Limite_Para_Todo_Estoque);
            var repo = new Mock<IProdutoRepository>();

            repo.Setup(r => r.TotalDeProdutos()).Returns(22);

            var alertaSpecification = new AlertaAplicadoParaTodosOsProdutosSpecification(repo.Object);

            Assert.True(alertaSpecification.IsSatisfiedBy(alerta));
        }

        [Fact]
        public void Alerta_AlertaAplicadoParaTodosOsProdutos_False()
        {
            var alerta = new Domain.Entities.Alerta("Winchester", 20, CondicoesDeAlerta.Definir_Limite_Para_Todo_Estoque);
            var repo = new Mock<IProdutoRepository>();

            repo.Setup(r => r.TotalDeProdutos()).Returns(18);

            var alertaSpecification = new AlertaAplicadoParaTodosOsProdutosSpecification(repo.Object);

            Assert.False(alertaSpecification.IsSatisfiedBy(alerta));
        }
    }
}