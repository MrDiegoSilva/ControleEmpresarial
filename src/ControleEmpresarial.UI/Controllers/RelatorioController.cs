using System;
using System.Web.Hosting;
using System.Web.Mvc;
using Rotativa;
using Rotativa.Options;

namespace ControleEmpresarial.UI.Controllers
{
    [AllowAnonymous]
    public class RelatorioController : ControllerBase
    {
        public ActionResult RelatorioSimples()
        {
            var customSwitches = "--header-html " + HostingEnvironment.MapPath("~/Views/Shared/Header.html") + " --footer-center \" \n  Emitido em : " + DateTime.Now + " - por : Diego Silva \n CAGEFOR \n Pg[page] / [toPage] \" --footer-font-size 9 --footer-spacing 5";
            return new ViewAsPdf()
            {
                PageSize = Size.A4,
                IsGrayScale = true,
                PageMargins = new Margins { Bottom = 20, Left = 20, Right = 20, Top = 45 },
                MinimumFontSize = 12,
                ViewName = "RelatorioSimples"
            };
        }
    }
}