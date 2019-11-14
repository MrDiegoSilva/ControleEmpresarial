using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ControleEmpresarial.Estoque.Application.Interface;
using ControleEmpresarial.Estoque.Application.ViewModel;
using ControleEmpresarial.UI.Models;

namespace ControleEmpresarial.UI.Controllers
{
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaAppService _marcaAppService;

        public MarcaController(IMarcaAppService marcaAppService)
        {
            _marcaAppService = marcaAppService;
        }

        public ActionResult Index()
        {
            return View(_marcaAppService.ObterTodos(true));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MarcaViewModel marcaiewViewModel)
        {
            _marcaAppService.Adicionar(marcaiewViewModel);
            if (Notifications.HasNotifications())
            {
                ValidarErrosDominio();
                return View(marcaiewViewModel);
            }
            TempData["AlertMessage"] = new List<string>() { "Marca cadastrada com sucesso!" };
            TempData["Mensagem"] = "Sucesso";
            return RedirectToAction("Estoque", "Home");
        }

        public ActionResult Edit(Guid id)
        {
            var marcaViewModel = _marcaAppService.ObterPorId(id);
            if (marcaViewModel != null)
                return View(marcaViewModel);
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(MarcaViewModel marcaViewModel)
        {
            if (ModelState.IsValid)
            {
                _marcaAppService.Atualizar(marcaViewModel);
                return RedirectToAction("Estoque", "Home");
            }
            return View(marcaViewModel);
        }

        public ActionResult Details(Guid id)
        {
            var marcaViewModel = _marcaAppService.ObterPorId(id);
            if (marcaViewModel != null)
                return View(marcaViewModel);
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            _marcaAppService.Excluir(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CapturarMarcasAutoComplete(string query)
        {
            return Json(_GetMarcas(query), JsonRequestBehavior.AllowGet);
        }

        private List<Autocomplete> _GetMarcas(string query)
        {
            var marcas = new List<Autocomplete>();
            var results = _marcaAppService.RetornarListaPorDescricao(query);

            marcas.AddRange(results.Select(r => new Autocomplete
            {
                Name = r.Descricao,
                Id = r.Id
            }));
            return marcas;
        }

        public ActionResult BuscarMarca()
        {
            return View();
        }

        public ActionResult RetornarBusca(MarcaViewModel marcaViewModel)
        {
            var lista = _marcaAppService.RetornarListaPorDescricao(marcaViewModel.Descricao);
            return PartialView("_ListaDeMarca", lista);
        }
    }
}