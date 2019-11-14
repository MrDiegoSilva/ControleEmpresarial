using ControleEmpresarial.Estoque.Domain.Entities.Enum;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Validation.Alerta;
using Moq;
using Xunit;

namespace ControleEmpresarial.Estoque.Test.Validation.Alerta
{
    public class AlertaAptoParaCadastroValidationTest
    {
        [Fact]
        public void Alerta_AdicionarExistente_ValidarResultadoFalse()
        {
            var alerta = new Domain.Entities.Alerta("Winchester",20, CondicoesDeAlerta.Definir_Limite_Para_Armazenamento);
            var repo = new Mock<IAlertaRepository>();

            repo.Setup(r => r.RetornarPorDescricao(alerta.Descricao)).Returns(alerta);

            var alertaValido = new AlertaAptoParaCadastroValidation(repo.Object);

            Assert.False(alertaValido.Validate(alerta).IsValid);
        }

        [Fact]
        public void Alerta_AdicionarExistente_ValidarResultadoTrue()
        {
            var alerta = new Domain.Entities.Alerta("Winchester", 20, CondicoesDeAlerta.Definir_Limite_Para_Armazenamento);
            var repo = new Mock<IAlertaRepository>();

            repo.Setup(r => r.RetornarPorDescricao(alerta.Descricao)).Returns((Domain.Entities.Alerta)null);

            var alertaValido = new AlertaAptoParaCadastroValidation(repo.Object);

            Assert.True(alertaValido.Validate(alerta).IsValid);
        }
    }
}