using ControleEmpresarial.Estoque.IntegrationTest.Config;
using TechTalk.SpecFlow;
using Xunit;

namespace ControleEmpresarial.Estoque.IntegrationTest.Material.CadastrarMaterial
{
    [Binding]
    public class CadastrarUmNovoMaterial
    {
        public SeleniumHelper Browser;

        public CadastrarUmNovoMaterial()
        {
            Browser = SeleniumHelper.Instance();
        }

        [Given(@"que o usuário está no site, na tela inicial, para cadastrar um novo material")]
        public void DadoQueOUsuarioEstaNoSiteNaPaginaInicial()
        {
            var url = Browser.NavegarParaSite("http://localhost:58355/Material/Create");

            Assert.Equal("http://localhost:58355/Material/Create", url);
        }

        //[Given(@"clica na tab Material")]
        //public void DadoClicaNaTabMaterial()
        //{
        //    Browser.ClicarLinkSite("Material");
        //}

        //[Given(@"clica no link Materiais")]
        //public void DadoClicaNoLinkMaterial()
        //{
        //    Browser.ClicarLinkSite("Materiais");
        //}

        //[Given(@"clica no link Novo Material")]
        //public void DadoClicaNoLinkCadastrar()
        //{
        //    Browser.ClicarLinkSite("Novo Material");
        //}

        [Given(@"preenche os campos com os valores do material")]
        public void DadoPreencheOsCamposComOsValores(Table table)
        {
            Browser.PreencherTextBox("Descricao", table.Rows[0][1]);
        }

        [When(@"clicar no botao registrar material")]
        public void QuandoClicarNoBotaoRegistrar()
        {
            Browser.ClicarBotaoSite("Registrar");
        }

        [Then(@"Recebe uma mensagem de cadastro material com sucesso")]
        public void EntaoRecebeUmaMensagemDeCadastroComSucesso()
        {
            var returnText = Browser.ObterTextoElementoPorClasse("msgRetorno");
            Assert.True(returnText.ToLower().Contains("material cadastrada com sucesso!"));
        }

        [Then(@"Recebe uma mensagem de erro pois o material já existe no banco")]
        public void EntaoRecebeUmaMensagemDeErroPoisOMaterialJaExisteNoBanco()
        {
            var returnText = Browser.ObterTextoElementoPorClasse("msgRetorno");
            Assert.True(returnText.ToLower().Contains("material já cadastrada!"));
        }

        [Then(@"Recebe uma mensagem de erro pois o material não possui descrição")]
        public void EntaoRecebeUmaMensagemDeErroPoisoMaterialNaoPossuiDescricao()
        {
            var returnText = Browser.ObterTextoElementoPorClasse("msgRetorno");
            Assert.True(returnText.ToLower().Contains("a descrição é obrigatória"));
        }
    }
}