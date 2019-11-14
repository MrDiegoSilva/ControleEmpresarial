using ControleEmpresarial.Estoque.IntegrationTest.Config;
using TechTalk.SpecFlow;
using Xunit;

namespace ControleEmpresarial.Estoque.IntegrationTest.Produto.CadastrarProduto
{
    [Binding]
    public class CadastrarUmNovoProduto
    {
        public SeleniumHelper Browser;

        public CadastrarUmNovoProduto()
        {
            Browser = SeleniumHelper.Instance();
        }

        [Given(@"que o usuário está no site, na tela inicial, para cadastrar um novo produto")]
        public void DadoQueOUsuarioEstaNoSiteNaPaginaInicial()
        {
            var url = Browser.NavegarParaSite("http://localhost:58355/Home/Estoque/");

            Assert.Equal("http://localhost:58355/Home/Estoque/", url);
        }

        [Given(@"clica na tab Produto")]
        public void DadoClicaNaTabProduto()
        {
            Browser.ClicarLinkSite("Produto");
        }

        [Given(@"clica no link Produtos")]
        public void DadoClicaNoLinkProdutos()
        {
            Browser.ClicarLinkSite("Produtos");
        }

        [Given(@"clica no link Novo Produto")]
        public void DadoClicaNoLinkNovoProduto()
        {
            Browser.ClicarLinkSite("Novo Produto");
        }

        [Given(@"preenche os campos com os valores do produto")]
        public void DadoPreencheOsCamposComOsValores(Table table)
        {
            Browser.PreencherTextBox("Codigo", table.Rows[0][1]);
            Browser.PreencherTextBox("Cor", table.Rows[1][1]);
            Browser.PreencherTextBox("Tamanho", table.Rows[2][1]);
            Browser.PreencherTextBox("Comprimento", table.Rows[3][1]);
            Browser.PreencherTextBox("Curvatura", table.Rows[4][1]);
            Browser.PreencherTextBox("ValorCompra", table.Rows[5][1]);
            Browser.PreencherTextBox("ValorVenda", table.Rows[6][1]);
            Browser.PreencherTextBox("DataEntrada", table.Rows[7][1]);
            Browser.PreencherTextBox("Marca_Descricao", table.Rows[8][1]);
            Browser.PreencherTextBox("Material_Descricao", table.Rows[9][1]);
            Browser.PreencherTextBox("Categoria_Descricao", table.Rows[10][1]);
        }

        [When(@"clicar no botao registrar produto")]
        public void QuandoClicarNoBotaoRegistrar()
        {
            Browser.ClicarBotaoSite("Registrar");
        }

        [Then(@"Recebe uma mensagem de cadastro de produto realizado com sucesso")]
        public void EntaoRecebeUmaMensagemDeCadastroComSucesso()
        {
            var returnText = Browser.ObterTextoElementoPorClasse("msgRetorno");
            Assert.True(returnText.ToLower().Contains("produto cadastrado com sucesso"));
        }

        [Then(@"Recebe uma mensagem de erro pois o produto já existe no banco")]
        public void EntaoRecebeUmaMensagemDeErroPoisOProdutoJaExisteNoBanco()
        {
            var returnText = Browser.ObterTextoElementoPorClasse("msgRetorno");
            Assert.True(returnText.ToLower().Contains("produto já cadastrado!"));
        }

        [Then(@"Recebe uma mensagem de erro pois o produto não possui codigo")]
        public void EntaoRecebeUmaMensagemDeErroPoisOProdutoNaoPossuiCodigo()
        {
            var returnText = Browser.ObterTextoElementoPorClasse("msgRetorno");
            Assert.True(returnText.ToLower().Contains("o código é obrigatório!"));
        }
    }
}