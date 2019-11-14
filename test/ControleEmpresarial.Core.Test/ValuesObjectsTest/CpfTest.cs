using ControleEmpresarial.Core.Domain.ValuesObjects;
using Xunit;

namespace ControleEmpresarial.Core.Teste.ValuesObjectsTest
{
    public class CpfTest
    {
        [Fact]
        public void Cpf_ValidarCpf_True()
        {
            Assert.True(CPF.Validar("01109559275"));
        }

        [Fact]
        public void Cpf_ValidarCpf_False()
        {
            Assert.False(CPF.Validar("12345678930"));
        }

        [Fact]
        public void Cpf_CompletarCpfInconpleto_True()
        {
            var validacao = new CPF("1109559275");
            var validacao2 = new CPF("16204166204");

            Assert.Equal(11, validacao.GetCpfCompleto().Length);
            Assert.Equal("01109559275", validacao.GetCpfCompleto());

            Assert.Equal(11, validacao2.GetCpfCompleto().Length);
            Assert.Equal("16204166204", validacao2.GetCpfCompleto());
        }

        [Fact]
        public void Cpf_LimparCpfQueIniciaComZero_True()
        {
            Assert.Equal(10, CPF.CpfLimpo("01109559275").Length);
            Assert.Equal("1109559275", CPF.CpfLimpo("01109559275"));


            Assert.Equal(11, CPF.CpfLimpo("16204166204").Length);
            Assert.Equal("16204166204", CPF.CpfLimpo("16204166204"));
        }

    }
}