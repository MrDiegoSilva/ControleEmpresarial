using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ControleEmpresarial.Estoque.IntegrationTest.Config
{
    public class SeleniumHelper
    {
        public static IWebDriver Cb;
        public WebDriverWait Wait;

        private static SeleniumHelper _instance;
        public static SeleniumHelper Instance()
        {
            return _instance ?? (_instance = new SeleniumHelper());
        }

        protected SeleniumHelper()
        {
            Cb = new ChromeDriver(ConfigurationHelper.ChromeDrive);
            Wait = new WebDriverWait(Cb, TimeSpan.FromSeconds(30));
        }

        public void AguardarEmSegundos(int segundos)
        {
            Cb.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(segundos));
        }

        public string ObterUrl()
        {
            return Cb.Url;
        }

        public bool ValidarConteudoUrl(string conteudo)
        {
            return Wait.Until(ExpectedConditions.UrlContains(conteudo));
        }

        public string NavegarParaSite(string url)
        {
            Cb.Navigate().GoToUrl(url);
            return ObterUrl();
        }

        public void ClicarLinkSite(string linkText)
        {
            var link = Wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(linkText)));
            link.Click();
        }

        public void PreencherTextBox(string idCampo, string valorCampo)
        {
            var campo = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(idCampo)));
            campo.SendKeys(valorCampo);
        }

        public void ClicarBotaoSite(string botaoId)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(botaoId))).Click();
        }

        public string ObterTextoElementoPorClasse(string className)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(className))).Text;
        }

        public IEnumerable<IWebElement> ObterListaPorClasse(string className)
        {
            return Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName(className)));
        }

        public void ObterScreenShot(string nome)
        {
            var screenshot = ((ITakesScreenshot)Cb).GetScreenshot();
            SalvarScreenShot(screenshot, string.Format("{0}_" + nome + ".png", DateTime.Now.ToFileTime()));
        }

        private static void SalvarScreenShot(Screenshot screenshot, string fileName)
        {
            screenshot.SaveAsFile(string.Format("{0}{1}", ConfigurationHelper.FolderPicture, fileName), ImageFormat.Png);
        }

        public void Fechar()
        {
            Cb.Close();
            Cb.Quit();
        }
    }
}