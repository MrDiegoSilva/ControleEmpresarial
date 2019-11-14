using ControleEmpresarial.Estoque.Domain.Entities.Enum;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Alerta;
using Moq;
using Xunit;

namespace ControleEmpresarial.Estoque.Test.Specification.Alerta
{
    public class AlertaDeveSerUnicoSpecificationTest
    {
        [Fact]
        public void Alerta_DeveSerUnica_False()
        {
            var alerta = new Domain.Entities.Alerta("Winchester",20, CondicoesDeAlerta.Definir_Limite_Para_Armazenamento);
            var repo = new Mock<IAlertaRepository>();

            repo.Setup(r => r.RetornarPorDescricao(alerta.Descricao)).Returns(alerta);

            var alertaSpecification = new AlertaDeveSerUnicoSpecification(repo.Object);

            Assert.False(alertaSpecification.IsSatisfiedBy(alerta));
        }

        [Fact]
        public void Alerta_DeveSerUnica_True()
        {
            var alerta = new Domain.Entities.Alerta("Winchester",20, CondicoesDeAlerta.Definir_Limite_Para_Armazenamento);
            var repo = new Mock<IAlertaRepository>();

            repo.Setup(r => r.RetornarPorDescricao(alerta.Descricao)).Returns((Domain.Entities.Alerta)null);

            var alertaSpecification = new AlertaDeveSerUnicoSpecification(repo.Object);

            Assert.True(alertaSpecification.IsSatisfiedBy(alerta));
        }
    }
}