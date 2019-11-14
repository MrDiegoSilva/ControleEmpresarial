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
namespace ControleEmpresarial.Estoque.IntegrationTest.Material.CadastrarMaterial
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class CadastrarUmaNovoMaterialFeature : Xunit.IClassFixture<CadastrarUmaNovoMaterialFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "CadastrarUmNovoMaterial.feature"
#line hidden
        
        public CadastrarUmaNovoMaterialFeature(CadastrarUmaNovoMaterialFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "Cadastrar uma novo material", "\tO usuário fará o cadastro de um novo material pelo site\r\n\tpreenchendo os campos " +
                    "necessários\r\n\tao terminar receberá uma notificacao \r\n\tde sucesso ou de falha", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        [Xunit.FactAttribute(DisplayName="Cadastrar material com sucesso")]
        [Xunit.TraitAttribute("FeatureTitle", "Cadastrar uma novo material")]
        [Xunit.TraitAttribute("Description", "Cadastrar material com sucesso")]
        [Xunit.TraitAttribute("Category", "TesteAceitacaoCadastroMaterial")]
        public virtual void CadastrarMaterialComSucesso()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cadastrar material com sucesso", new string[] {
                        "TesteAceitacaoCadastroMaterial"});
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
 testRunner.Given("que o usuário está no site, na tela inicial, para cadastrar um novo material", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Campo",
                        "Valor"});
            table1.AddRow(new string[] {
                        "Descricao",
                        "Material Teste"});
#line 14
 testRunner.And("preenche os campos com os valores do material", ((string)(null)), table1, "E ");
#line 17
 testRunner.When("clicar no botao registrar material", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 18
 testRunner.Then("Recebe uma mensagem de cadastro material com sucesso", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Cadastrar material já existente no banco")]
        [Xunit.TraitAttribute("FeatureTitle", "Cadastrar uma novo material")]
        [Xunit.TraitAttribute("Description", "Cadastrar material já existente no banco")]
        public virtual void CadastrarMaterialJaExistenteNoBanco()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cadastrar material já existente no banco", ((string[])(null)));
#line 20
 this.ScenarioSetup(scenarioInfo);
#line 21
 testRunner.Given("que o usuário está no site, na tela inicial, para cadastrar um novo material", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Campo",
                        "Valor"});
            table2.AddRow(new string[] {
                        "Descricao",
                        "Material Teste"});
#line 25
 testRunner.And("preenche os campos com os valores do material", ((string)(null)), table2, "E ");
#line 28
 testRunner.When("clicar no botao registrar material", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 29
 testRunner.Then("Recebe uma mensagem de erro pois o material já existe no banco", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Cadastrar material sem descrição")]
        [Xunit.TraitAttribute("FeatureTitle", "Cadastrar uma novo material")]
        [Xunit.TraitAttribute("Description", "Cadastrar material sem descrição")]
        public virtual void CadastrarMaterialSemDescricao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cadastrar material sem descrição", ((string[])(null)));
#line 31
 this.ScenarioSetup(scenarioInfo);
#line 32
 testRunner.Given("que o usuário está no site, na tela inicial, para cadastrar um novo material", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Campo",
                        "Valor"});
            table3.AddRow(new string[] {
                        "Descricao",
                        ""});
#line 36
 testRunner.And("preenche os campos com os valores do material", ((string)(null)), table3, "E ");
#line 39
 testRunner.When("clicar no botao registrar material", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 40
 testRunner.Then("Recebe uma mensagem de erro pois o material não possui descrição", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                CadastrarUmaNovoMaterialFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                CadastrarUmaNovoMaterialFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
