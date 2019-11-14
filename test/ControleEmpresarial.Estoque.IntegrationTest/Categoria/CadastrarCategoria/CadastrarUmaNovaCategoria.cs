using ControleEmpresarial.Estoque.IntegrationTest.Config;
using TechTalk.SpecFlow;
using Xunit;

namespace ControleEmpresarial.Estoque.IntegrationTest.Categoria.CadastrarCategoria
{
    [Binding]
    public class CadastrarUmaNovaCategoria
    {
        public SeleniumHelper Browser;

        public CadastrarUmaNovaCategoria()
        {
            Browser = SeleniumHelper.Instance();
        }

        [Given(@"que o usuário está no site, na tela inicial, para cadastrar uma nova categoria")]
        public void DadoQueOUsuarioEstaNoSiteNaPaginaInicial()
        {
            var url = Browser.NavegarParaSite("http://localhost:58355/Home/Estoque/");

            Assert.Equal("http://localhost:58355/Home/Estoque/", url);
        }

        [Given(@"clica na tab categoria")]
        public void DadoClicaNaTabCategoria()
        {
            Browser.ClicarLinkSite("Categoria");
        }

        [Given(@"clica no link Categorias")]
        public void DadoClicaNoLinkCategoria()
        {
            Browser.ClicarLinkSite("Categorias");
        }

        [Given(@"clica no link Nova Categoria")]
        public void DadoClicaNoLinkCadastrar()
        {
            Browser.ClicarLinkSite("Nova Categoria");
        }

        [Given(@"preenche oo formulario com os valores")]
        public void DadoPreencheOsCamposComOsValores(Table table)
        {
            Browser.PreencherTextBox("Descricao", table.Rows[0][1]);
        }

        [When(@"clicar no botao registrar categoria")]
        public void QuandoClicarNoBotaoRegistrar()
        {
            Browser.ClicarBotaoSite("RegistrarCategoria");
        }

        [Then(@"Recebe uma mensagem de cadastro categoria com sucesso")]
        public void EntaoRecebeUmaMensagemDeCadastroComSucesso()
        {
            var returnText = Browser.ObterTextoElementoPorClasse("msgRetorno");
            Assert.True(returnText.ToLower().Contains("categoria cadastrada com sucesso!"));
        }

        [Then(@"Recebe uma mensagem de erro pois a categoria já existe no banco")]
        public void EntaoRecebeUmaMensagemDeErroPoisAMarcaJaExisteNoBanco()
        {
            var returnText = Browser.ObterTextoElementoPorClasse("msgRetorno");
            Assert.True(returnText.ToLower().Contains("categoria já cadastrada!"));
        }

        [Then(@"Recebe uma mensagem de erro pois a categoria não possui descrição")]
        public void EntaoRecebeUmaMensagemDeErroPoisACategoriaNaoPossuiDescricao()
        {
            var returnText = Browser.ObterTextoElementoPorClasse("msgRetorno");
            Assert.True(returnText.ToLower().Contains("a descrição é obrigatória"));
        }
    }
}