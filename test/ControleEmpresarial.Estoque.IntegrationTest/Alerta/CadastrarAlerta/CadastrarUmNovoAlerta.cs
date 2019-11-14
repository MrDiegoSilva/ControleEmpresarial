using ControleEmpresarial.Estoque.IntegrationTest.Config;
using TechTalk.SpecFlow;
using Xunit;

namespace ControleEmpresarial.Estoque.IntegrationTest.Alerta.CadastrarAlerta
{
    [Binding]
    public class CadastrarUmNovoAlerta
    {
        public SeleniumHelper Browser;

        public CadastrarUmNovoAlerta()
        {
            Browser = SeleniumHelper.Instance();
        }

        [Given(@"que o usuário está no site, na tela inicial, para cadastrar uma novo alerta")]
        public void DadoQueOUsuarioEstaNoSiteNaPaginaInicial()
        {
            var url = Browser.NavegarParaSite("http://localhost:58355/Home/Estoque/");

            Assert.Equal("http://localhost:58355/Home/Estoque/", url);
        }

        [Given(@"clica na tab Alerta")]
        public void DadoClicaNaTabAlerta()
        {
            Browser.ClicarLinkSite("Alerta");
        }

        [Given(@"clica no link Alertas")]
        public void DadoClicaNoLinkAlertas()
        {
            Browser.ClicarLinkSite("Alertas");
        }

        [Given(@"clica no link Novo Alerta")]
        public void DadoClicaNoLinkCadastrar()
        {
            Browser.ClicarLinkSite("Novo Alerta");
        }

        [Given(@"preenche os campos com os valores do alerta")]
        public void DadoPreencheOsCamposComOsValores(Table table)
        {
            Browser.PreencherTextBox("Descricao", table.Rows[0][1]);
            Browser.PreencherTextBox("Quantidade", table.Rows[1][1]);
        }

        [When(@"clicar no botao registrar alerta")]
        public void QuandoClicarNoBotaoRegistrar()
        {
            Browser.ClicarBotaoSite("RegistrarAlerta");
        }

        [Then(@"Recebe uma mensagem de cadastro de alerta com sucesso")]
        public void EntaoRecebeUmaMensagemDeCadastroComSucesso()
        {
            var returnText = Browser.ObterTextoElementoPorClasse("msgRetorno");
            Assert.True(returnText.ToLower().Contains("alerta cadastrado com sucesso!"));
        }

        [Then(@"Recebe uma mensagem de erro pois o alerta já existe no banco")]
        public void EntaoRecebeUmaMensagemDeErroPoisOAlertaJaExisteNoBanco()
        {
            var returnText = Browser.ObterTextoElementoPorClasse("msgRetorno");
            Assert.True(returnText.ToLower().Contains("alerta já cadastrado!"));
        }

        [Then(@"Recebe uma mensagem de erro poiso alerta não possui descrição")]
        public void EntaoRecebeUmaMensagemDeErroPoisOAlertaNaoPossuiDescricao()
        {
            var returnText = Browser.ObterTextoElementoPorClasse("msgRetorno");
            Assert.True(returnText.ToLower().Contains("a descrição é obrigatória"));
        }

        [Then(@"Recebe uma mensagem de erro poiso alerta não possui quantidade")]
        public void EntaoRecebeUmaMensagemDeErroPoisOAlertaNaoPossuiQuantidade()
        {
            var returnText = Browser.ObterTextoElementoPorClasse("msgRetorno");
            Assert.True(returnText.ToLower().Contains("a quantidade precisa ser maior que zero!"));
        }
    }
}