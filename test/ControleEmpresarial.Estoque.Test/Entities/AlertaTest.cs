using ControleEmpresarial.Estoque.Domain.Entities;
using ControleEmpresarial.Estoque.Domain.Entities.Enum;
using ControleEmpresarial.Estoque.Domain.Scopes;
using Xunit;

namespace ControleEmpresarial.Estoque.Test.Entities
{
    public class AlertaTest
    {
        [Fact]
        public void Alerta_ValidarDescricaoAlerta_True()
        {
            var alerta = new Alerta("Winchester",20, CondicoesDeAlerta.Definir_Limite_Para_Armazenamento);

            Assert.True(alerta.ValidarDescricaoEhValido(alerta.Descricao));
        }

        [Fact]
        public void Alerta_ValidarDescricaoAlerta_False()
        {
            var alerta = new Alerta(string.Empty, 20, CondicoesDeAlerta.Definir_Limite_Para_Armazenamento);

            Assert.False(alerta.ValidarDescricaoEhValido(alerta.Descricao));
        }

        [Fact]
        public void Alerta_ValidarQuantidadeAlerta_True()
        {
            var alerta = new Alerta("Winchester", 20, CondicoesDeAlerta.Definir_Limite_Para_Armazenamento);

            Assert.True(alerta.ValidarQuantidadeEhValido(alerta.Quantidade));
        }

        [Fact]
        public void Alerta_ValidarQuantidadeAlerta_False()
        {
            var alerta = new Alerta("Winchester", -1, CondicoesDeAlerta.Definir_Limite_Para_Armazenamento);

            Assert.False(alerta.ValidarQuantidadeEhValido(alerta.Quantidade));
        }

    }
}