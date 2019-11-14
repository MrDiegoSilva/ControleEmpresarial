using ControleEmpresarial.Core.Domain.ValuesObjects;
using Xunit;

namespace ControleEmpresarial.Core.Teste.ValuesObjectsTest
{
    public class AssertionConcernTest
    {
        [Fact]
        public void Assertion_ValidarAssertLength_True()
        {
            var validacao = AssertionConcern.AssertLength("DiegoTeste", 5, 10, "mensagem");
            Assert.True(AssertionConcern.IsSatisfiedBy(validacao));
        }

        [Fact]
        public void Assertion_ValidarAssertLength_False()
        {
            var validacaoTamanhoInsuficiente = AssertionConcern.AssertLength("DiegoTeste", 5, 9, "mensagem");
            var validacaoTamanhoExtrapolado = AssertionConcern.AssertLength("DiegoTeste", 12, 20, "mensagem");
            var validacaoTamanhoNull = AssertionConcern.AssertLength(null, 5, 9, "mensagem");
            var validacaoTamanhoVazio = AssertionConcern.AssertLength("", 5, 9, "mensagem");
            var validacaoTamanhoVazioComMinimoZero = AssertionConcern.AssertLength("", 0, 2, "mensagem");
            var validacaoParametrosIguais = AssertionConcern.AssertLength("Diego", 6, 5, "mensagem");

            Assert.False(AssertionConcern.IsSatisfiedBy(validacaoTamanhoInsuficiente));
            Assert.False(AssertionConcern.IsSatisfiedBy(validacaoTamanhoNull));
            Assert.False(AssertionConcern.IsSatisfiedBy(validacaoTamanhoVazio));
            Assert.False(AssertionConcern.IsSatisfiedBy(validacaoParametrosIguais));
            Assert.False(AssertionConcern.IsSatisfiedBy(validacaoTamanhoExtrapolado));
            Assert.False(AssertionConcern.IsSatisfiedBy(validacaoTamanhoVazioComMinimoZero));
        }

        [Fact]
        public void Assertion_ValidarAssertFixedLength_True()
        {
            var validacao = AssertionConcern.AssertFixedLength("Diego", 5, "mensagem");
            Assert.True(AssertionConcern.IsSatisfiedBy(validacao));
        }

        [Fact]
        public void Assertion_ValidarAssertFixedLength_False()
        {
            var validacaoTamanhoInsuficiente = AssertionConcern.AssertFixedLength("Diego", 10, "mensagem");
            var validacaoTamanhoExtrapolado = AssertionConcern.AssertFixedLength("DiegoTeste", 5, "mensagem");
            var validacaoTamanhoNull = AssertionConcern.AssertFixedLength(null, 5, "mensagem");
            var validacaoTamanhoVazio = AssertionConcern.AssertFixedLength("", 5, "mensagem");
            var validacaoTamanhoVazioComMinimoZero = AssertionConcern.AssertFixedLength("", 0, "mensagem");

            Assert.False(AssertionConcern.IsSatisfiedBy(validacaoTamanhoInsuficiente));
            Assert.False(AssertionConcern.IsSatisfiedBy(validacaoTamanhoNull));
            Assert.False(AssertionConcern.IsSatisfiedBy(validacaoTamanhoVazio));
            Assert.False(AssertionConcern.IsSatisfiedBy(validacaoTamanhoExtrapolado));
            Assert.False(AssertionConcern.IsSatisfiedBy(validacaoTamanhoVazioComMinimoZero));
        }

        [Fact]
        public void Assertion_ValidarAssertMatches_True()
        {
            var validacao = AssertionConcern.AssertMatches("PalavraChave", "PalavraChave", "mensagem");
            Assert.True(AssertionConcern.IsSatisfiedBy(validacao));
        }

        [Fact]
        public void Assertion_ValidarAssertMatches_False()
        {
            var validacaoChavesDiferentes = AssertionConcern.AssertMatches("PalavraChave", "PalavraChavi", "mensagem");
            var validacaoChaveNull = AssertionConcern.AssertMatches("PalavraChave", null, "mensagem");
            var validacaoPalavraNull = AssertionConcern.AssertMatches(null, "PalavraChave", "mensagem");
            var validacaoPalavraVazia = AssertionConcern.AssertMatches("", "PalavraChave", "mensagem");
            var validacaoChaveVazia = AssertionConcern.AssertMatches("PalavraChave", "", "mensagem");

            Assert.False(AssertionConcern.IsSatisfiedBy(validacaoChavesDiferentes));
            Assert.False(AssertionConcern.IsSatisfiedBy(validacaoChaveNull));
            Assert.False(AssertionConcern.IsSatisfiedBy(validacaoPalavraNull));
            Assert.False(AssertionConcern.IsSatisfiedBy(validacaoPalavraVazia));
            Assert.False(AssertionConcern.IsSatisfiedBy(validacaoChaveVazia));
        }

        [Fact]
        public void Assertion_ValidarAssertNotNullOrEmpty_True()
        {
            var validacao = AssertionConcern.AssertNotNullOrEmpty("PalavraChave", "memsagem");
            Assert.True(AssertionConcern.IsSatisfiedBy(validacao));
        }

        [Fact]
        public void Assertion_ValidarAssertNotNullOrEmpty_False()
        {
            var validacaoChavesVazia = AssertionConcern.AssertNotNullOrEmpty("", "memsagem");
            var validacaoChaveNull = AssertionConcern.AssertNotNullOrEmpty(null, "memsagem");

            Assert.False(AssertionConcern.IsSatisfiedBy(validacaoChavesVazia));
            Assert.False(AssertionConcern.IsSatisfiedBy(validacaoChaveNull));
        }

        [Fact]
        public void Assertion_ValidarAssertNotNull_True()
        {
            var validacao = AssertionConcern.AssertNotNull(new object(), "memsagem");
            Assert.True(AssertionConcern.IsSatisfiedBy(validacao));
        }

        [Fact]
        public void Assertion_ValidarAssertNotNull_False()
        {
            var validacaoChaveNull = AssertionConcern.AssertNotNull(null, "memsagem");
            Assert.False(AssertionConcern.IsSatisfiedBy(validacaoChaveNull));
        }

        [Fact]
        public void Assertion_ValidarAssertIsNull_True()
        {
            var validacao = AssertionConcern.AssertIsNull(null, "memsagem");
            Assert.True(AssertionConcern.IsSatisfiedBy(validacao));
        }

        [Fact]
        public void Assertion_ValidarAssertIsNull_False()
        {
            var validacaoChavePreenchida = AssertionConcern.AssertIsNull(new object(), "memsagem");
            Assert.False(AssertionConcern.IsSatisfiedBy(validacaoChavePreenchida));
        }

        [Fact]
        public void Assertion_ValidarAssertTrue_True()
        {
            var validacao = AssertionConcern.AssertTrue(true, "memsagem");
            Assert.True(AssertionConcern.IsSatisfiedBy(validacao));
        }

        [Fact]
        public void Assertion_ValidarAssertTrue_False()
        {
            var validacaoChaveFalse = AssertionConcern.AssertTrue(false, "memsagem");
            Assert.False(AssertionConcern.IsSatisfiedBy(validacaoChaveFalse));
        }

        [Fact]
        public void Assertion_ValidarAssertAreEquals_True()
        {
            var validacao = AssertionConcern.AssertAreEquals("PalavraChave", "PalavraChave", "memsagem");
            Assert.True(AssertionConcern.IsSatisfiedBy(validacao));
        }

        [Fact]
        public void Assertion_ValidarAssertAreEquals_False()
        {
            var validacaoChavesDiferentes = AssertionConcern.AssertAreEquals("PalavraChave", "PalavraDiferente", "memsagem");
            var validacaoChavesNull = AssertionConcern.AssertAreEquals(null, null, "memsagem");
            var validacaoChavesVazia = AssertionConcern.AssertAreEquals("", "", "memsagem");
            Assert.False(AssertionConcern.IsSatisfiedBy(validacaoChavesVazia));
            Assert.False(AssertionConcern.IsSatisfiedBy(validacaoChavesNull));
            Assert.False(AssertionConcern.IsSatisfiedBy(validacaoChavesDiferentes));
        }

        [Fact]
        public void Assertion_ValidarGreaterThanZero_True()
        {
            var validacao = AssertionConcern.AssertGreaterThanZero(1, "memsagem");
            Assert.True(AssertionConcern.IsSatisfiedBy(validacao));
        }

        [Fact]
        public void Assertion_ValidarGreaterThanZero_False()
        {
            var validacaoChavesDiferentes = AssertionConcern.AssertGreaterThanZero(-1, "memsagem");
            Assert.False(AssertionConcern.IsSatisfiedBy(validacaoChavesDiferentes));
        }
    }
}