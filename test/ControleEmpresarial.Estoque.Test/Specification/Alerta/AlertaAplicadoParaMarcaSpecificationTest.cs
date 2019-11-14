using ControleEmpresarial.Estoque.Domain.Entities.Enum;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Alerta;
using Moq;
using Xunit;

namespace ControleEmpresarial.Estoque.Test.Specification.Alerta
{
    public class AlertaAplicadoParaMarcaSpecificationTest
    {
        [Fact]
        public void Alerta_AlertaAplicadoParaArmazenamento_True()
        {
            var alerta = new Domain.Entities.Alerta("Winchester", 20, CondicoesDeAlerta.Definir_Limite_Por_Marca);
            var repo = new Mock<IProdutoRepository>();

            repo.Setup(r => r.TotalDeProdutosPorMarca(alerta.ValorCondicao)).Returns(22);

            var alertaSpecification = new AlertaAplicadoParaMarcaSpecification(repo.Object);

            Assert.True(alertaSpecification.IsSatisfiedBy(alerta));
        }

        [Fact]
        public void Alerta_AlertaAplicadoParaArmazenamento_False()
        {
            var alerta = new Domain.Entities.Alerta("Winchester", 20, CondicoesDeAlerta.Definir_Limite_Por_Marca);
            var repo = new Mock<IProdutoRepository>();

            repo.Setup(r => r.TotalDeProdutosPorMarca(alerta.ValorCondicao)).Returns(18);

            var alertaSpecification = new AlertaAplicadoParaMarcaSpecification(repo.Object);

            Assert.False(alertaSpecification.IsSatisfiedBy(alerta));
        }
    }
}