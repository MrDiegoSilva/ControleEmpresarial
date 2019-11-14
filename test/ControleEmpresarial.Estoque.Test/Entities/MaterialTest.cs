using ControleEmpresarial.Estoque.Domain.Entities;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Scopes;
using Moq;
using Xunit;

namespace ControleEmpresarial.Estoque.Test.Entities
{
    public class MaterialTest
    {
        [Fact]
        public void Material_ValidarMarca_True()
        {
            var material = new Material("plástico");
            var repo = new Mock<IMaterialRepository>();
            repo.Setup(r => r.RetornarPorDescricao(material.Descricao)).Returns((Material)null);
            Assert.True(material.IsValid(repo.Object));
        }

        [Fact]
        public void Material_ValidarMarca_False()
        {
            var material = new Material("plástico");
            var repo = new Mock<IMaterialRepository>();
            repo.Setup(r => r.RetornarPorDescricao(material.Descricao)).Returns(material);
            Assert.False(material.IsValid(repo.Object));
        }

        [Fact]
        public void Marca_VerificarDescriçãoValida_True()
        {
            var material = new Material("plástico");
            Assert.True(material.ValidarDescricaoEhValido(material.Descricao));
        }

        [Fact]
        public void Marca_VerificarDescriçãoValida_False()
        {
            var material = new Material("");
            Assert.False(material.ValidarDescricaoEhValido(material.Descricao));
        }
    }
}