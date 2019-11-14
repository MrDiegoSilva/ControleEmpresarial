using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using ControleEmpresarial.Estoque.Application.Interface;
using ControleEmpresarial.Estoque.Application.ViewModel;

namespace ControleEmpresarial.UI.Controllers
{
    public class AlertaController : ControllerBase
    {
        private readonly IAlertaAppService _alertaAppService;

        public AlertaController(IAlertaAppService alertaAppService)
        {
            _alertaAppService = alertaAppService;
        }

        public ActionResult Index()
        {
            return View(_alertaAppService.ObterTodos(true));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AlertaViewModel alertaViewModel)
        {
            if (!ModelState.IsValid) return View(alertaViewModel);
            _alertaAppService.Adicionar(alertaViewModel);
            if (Notifications.HasNotifications())
            {
                ValidarErrosDominio();
                return View(alertaViewModel);
            }
            TempData["AlertMessage"] = new List<string>() { "Alerta cadastrado com sucesso!" };
            TempData["Mensagem"] = "Sucesso";
            return RedirectToAction("Estoque", "Home");
        }

        public ActionResult Edit(Guid id)
        {
            var alertaViewModel = _alertaAppService.ObterPorId(id);
            if (alertaViewModel != null)
                return View(alertaViewModel);
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(AlertaViewModel alertaViewModel)
        {
            if (ModelState.IsValid)
            {
                _alertaAppService.Atualizar(alertaViewModel);
                return RedirectToAction("Estoque", "Home");
            }
            return View(alertaViewModel);
        }

        public ActionResult Details(Guid id)
        {
            var alertaViewModel = _alertaAppService.ObterPorId(id);
            if (alertaViewModel != null)
                return View(alertaViewModel);
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            _alertaAppService.Excluir(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }


        public PartialViewResult VerificarAlertas()
        {
            var resultado = _alertaAppService.VerificarAlertasDisparados();
            if (resultado.Result > 0)
            {
                TempData["alerta"] = $"<div class='label label-danger pull-right'>{resultado.Result}</div>";
            }
            return PartialView("_VerificarAlerta");
        }

        public ActionResult BuscarAlerta()
        {
            return View();
        }

        public ActionResult RetornarBusca(AlertaViewModel alertaViewModel)
        {
            var lista = _alertaAppService.BuscarAlerta(alertaViewModel);
            return PartialView("_ListaDeAlertas", lista);
        }

    }
}