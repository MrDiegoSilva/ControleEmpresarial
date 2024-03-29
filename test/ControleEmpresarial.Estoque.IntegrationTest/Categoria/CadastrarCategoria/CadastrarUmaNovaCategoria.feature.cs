﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ControleEmpresarial.Estoque.IntegrationTest.Categoria.CadastrarCategoria
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class CadastrarUmaNovaCategoriaFeature : Xunit.IClassFixture<CadastrarUmaNovaCategoriaFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "CadastrarUmaNovaCategoria.feature"
#line hidden
        
        public CadastrarUmaNovaCategoriaFeature(CadastrarUmaNovaCategoriaFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "Cadastrar uma nova categoria", "\tO usuário fará o cadastro de uma categoria pelo site\r\n\tpreenchendo os campos nec" +
                    "essários\r\n\tao terminar receberá uma notificacao \r\n\tde sucesso ou de falha", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Cadastrar categoria com sucesso")]
        [Xunit.TraitAttribute("FeatureTitle", "Cadastrar uma nova categoria")]
        [Xunit.TraitAttribute("Description", "Cadastrar categoria com sucesso")]
        [Xunit.TraitAttribute("Category", "TesteAceitacaoCadastroCategoria")]
        public virtual void CadastrarCategoriaComSucesso()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cadastrar categoria com sucesso", new string[] {
                        "TesteAceitacaoCadastroCategoria"});
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
 testRunner.Given("que o usuário está no site, na tela inicial, para cadastrar uma nova categoria", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 11
 testRunner.And("clica na tab categoria", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 12
 testRunner.And("clica no link Categorias", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 13
 testRunner.And("clica no link Nova Categoria", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Campo",
                        "Valor"});
            table1.AddRow(new string[] {
                        "Descricao",
                        "Armação Teste"});
#line 14
 testRunner.And("preenche oo formulario com os valores", ((string)(null)), table1, "E ");
#line 17
 testRunner.When("clicar no botao registrar categoria", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 18
 testRunner.Then("Recebe uma mensagem de cadastro categoria com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Cadastrar categoria já existente no banco")]
        [Xunit.TraitAttribute("FeatureTitle", "Cadastrar uma nova categoria")]
        [Xunit.TraitAttribute("Description", "Cadastrar categoria já existente no banco")]
        public virtual void CadastrarCategoriaJaExistenteNoBanco()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cadastrar categoria já existente no banco", ((string[])(null)));
#line 20
 this.ScenarioSetup(scenarioInfo);
#line 21
 testRunner.Given("que o usuário está no site, na tela inicial, para cadastrar uma nova categoria", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 22
 testRunner.And("clica na tab categoria", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 23
 testRunner.And("clica no link Categorias", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 24
 testRunner.And("clica no link Nova Categoria", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Campo",
                        "Valor"});
            table2.AddRow(new string[] {
                        "Descricao",
                        "Armação Teste"});
#line 25
 testRunner.And("preenche oo formulario com os valores", ((string)(null)), table2, "E ");
#line 28
 testRunner.When("clicar no botao registrar categoria", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 29
 testRunner.Then("Recebe uma mensagem de erro pois a categoria já existe no banco", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Cadastrar categoria sem descrição")]
        [Xunit.TraitAttribute("FeatureTitle", "Cadastrar uma nova categoria")]
        [Xunit.TraitAttribute("Description", "Cadastrar categoria sem descrição")]
        public virtual void CadastrarCategoriaSemDescricao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cadastrar categoria sem descrição", ((string[])(null)));
#line 31
 this.ScenarioSetup(scenarioInfo);
#line 32
 testRunner.Given("que o usuário está no site, na tela inicial, para cadastrar uma nova categoria", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 33
 testRunner.And("clica na tab categoria", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 34
 testRunner.And("clica no link Categorias", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 35
 testRunner.And("clica no link Nova Categoria", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Campo",
                        "Valor"});
            table3.AddRow(new string[] {
                        "Descricao",
                        ""});
#line 36
 testRunner.And("preenche oo formulario com os valores", ((string)(null)), table3, "E ");
#line 39
 testRunner.When("clicar no botao registrar categoria", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 40
 testRunner.Then("Recebe uma mensagem de erro pois a categoria não possui descrição", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                CadastrarUmaNovaCategoriaFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                CadastrarUmaNovaCategoriaFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
