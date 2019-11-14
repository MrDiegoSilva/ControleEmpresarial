using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ControleEmpresarial.Estoque.Application.Interface;
using ControleEmpresarial.Estoque.Application.ViewModel;
using ControleEmpresarial.UI.Models;

namespace ControleEmpresarial.UI.Controllers
{
    public class LocalController : ControllerBase
    {
        private readonly ILocalidadeAppService _localidadeAppService;

        public LocalController(ILocalidadeAppService localidadeAppService)
        {
            _localidadeAppService = localidadeAppService;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LocalidadeViewModel localidadeViewModel)
        {
            _localidadeAppService.Adicionar(localidadeViewModel);
            if (Notifications.HasNotifications())
            {
                ValidarErrosDominio();
                return View(localidadeViewModel);
            }
            TempData["AlertMessage"] = new List<string>() { "Localidade cadastrada com sucesso!" };
            TempData["Mensagem"] = "Sucesso";
            return RedirectToAction("Estoque", "Home");
        }

        public ActionResult Edit(Guid id)
        {
            var localidadeViewModel = _localidadeAppService.ObterPorId(id);
            if (localidadeViewModel != null)
                return View(localidadeViewModel);
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(LocalidadeViewModel localidadeViewModel)
        {
            if (ModelState.IsValid)
            {
                _localidadeAppService.Atualizar(localidadeViewModel);
                return RedirectToAction("Estoque", "Home");
            }
            return View(localidadeViewModel);
        }

        public ActionResult Details(Guid id)
        {
            var localidadeViewModel = _localidadeAppService.ObterPorId(id);
            if (localidadeViewModel != null)
                return View(localidadeViewModel);
            return HttpNotFound();
        }

        public ActionResult Delete(Guid id)
        {
            var localidadeViewModel = _localidadeAppService.ObterPorId(id);
            if (localidadeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(localidadeViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _localidadeAppService.Excluir(id);
            return RedirectToAction("Estoque", "Home");
        }

        public ActionResult CapturarLocalidadeAutoComplete(string query)
        {
            return Json(_GetLocalidade(query), JsonRequestBehavior.AllowGet);
        }

        private List<Autocomplete> _GetLocalidade(string query)
        {
            var localidades = new List<Autocomplete>();

            var results = _localidadeAppService.RetornarListaPorDescricao(query);

            localidades.AddRange(results.Select(r => new Autocomplete
            {
                Name = r.Descricao,
                Id = r.Id
            }));
            return localidades;
        }

        public ActionResult BuscarLocalidade()
        {
            return View();
        }

        public ActionResult RetornarBusca(LocalidadeViewModel localidadeViewModel)
        {
            var lista = _localidadeAppService.RetornarListaPorDescricao(localidadeViewModel.Descricao);
            return PartialView("_ListaDeLocalidades", lista);
        }
    }
}