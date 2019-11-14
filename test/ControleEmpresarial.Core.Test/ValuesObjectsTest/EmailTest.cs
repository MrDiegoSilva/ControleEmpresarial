using ControleEmpresarial.Core.Domain.ValuesObjects;
using Xunit;

namespace ControleEmpresarial.Core.Teste.ValuesObjectsTest
{
    public class EmailTest
    {
        [Fact]
        public void Email_ValidarEmail_True()
        {
            Assert.True(Email.IsValid("email.emailvalido@email.com"));
        }

        [Fact]
        public void Email_ValidarEmail_False()
        {
            Assert.False(Email.IsValid("email.email@invalido@email.com"));
            Assert.False(Email.IsValid("email.emailinvalido.email.com"));
        }
    }
}