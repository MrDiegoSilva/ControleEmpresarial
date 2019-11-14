using ControleEmpresarial.Estoque.IntegrationTest.Config;
using TechTalk.SpecFlow;
using Xunit;

namespace ControleEmpresarial.Estoque.IntegrationTest.Marca.CadastrarMarca
{
    [Binding]
    public class CadastrarUmaNovaMarca
    {
        public SeleniumHelper Browser;

        public CadastrarUmaNovaMarca()
        {
            Browser = SeleniumHelper.Instance();
        }

        [Given(@"que o usuário está no site, na tela inicial, para cadastrar uma nova marca")]
        public void DadoQueOUsuarioEstaNoSiteNaPaginaInicial()
        {
            var url = Browser.NavegarParaSite("http://localhost:58355/Home/Estoque/");

            Assert.Equal("http://localhost:58355/Home/Estoque/", url);
        }

        [Given(@"clica na tab Marca")]
        public void DadoClicaNaTabMarca()
        {
            Browser.ClicarLinkSite("Marca");
        }

        [Given(@"clica no link Marcas")]
        public void DadoClicaNoLinkMarcas()
        {
            Browser.ClicarLinkSite("Marcas");
        }

        [Given(@"clica no link Nova Marca")]
        public void DadoClicaNoLinkCadastrar()
        {
            Browser.ClicarLinkSite("Nova Marca");
        }

        [Given(@"preenche os campos com os valores")]
        public void DadoPreencheOsCamposComOsValores(Table table)
        {
            Browser.PreencherTextBox("Descricao", table.Rows[0][1]);
        }

        [When(@"clicar no botao registrar")]
        public void QuandoClicarNoBotaoRegistrar()
        {
            Browser.ClicarBotaoSite("RegistrarMarca");
        }

        [Then(@"Recebe uma mensagem de cadastro com sucesso")]
        public void EntaoRecebeUmaMensagemDeCadastroComSucesso()
        {
            var returnText = Browser.ObterTextoElementoPorClasse("msgRetorno");
            Assert.True(returnText.ToLower().Contains("marca cadastrada com sucesso!"));
        }

        [Then(@"Recebe uma mensagem de erro pois a marca já existe no banco")]
        public void EntaoRecebeUmaMensagemDeErroPoisAMarcaJaExisteNoBanco()
        {
            var returnText = Browser.ObterTextoElementoPorClasse("msgRetorno");
            Assert.True(returnText.ToLower().Contains("marca já cadastrada!"));
        }

        [Then(@"Recebe uma mensagem de erro pois a marca não possui descrição")]
        public void EntaoRecebeUmaMensagemDeErroPoisAMarcaNaoPossuiDescricao()
        {
            var returnText = Browser.ObterTextoElementoPorClasse("msgRetorno");
            Assert.True(returnText.ToLower().Contains("a descrição é obrigatória"));
        }
    }
}