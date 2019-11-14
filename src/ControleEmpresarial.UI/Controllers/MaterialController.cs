using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ControleEmpresarial.Estoque.Application.Interface;
using ControleEmpresarial.Estoque.Application.ViewModel;
using ControleEmpresarial.UI.Models;

namespace ControleEmpresarial.UI.Controllers
{
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialAppService _materialAppService;

        public MaterialController(IMaterialAppService materialAppService)
        {
            _materialAppService = materialAppService;
        }

        public ActionResult Index()
        {
            return View(_materialAppService.ObterTodos(true));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MaterialViewModel materialViewModel)
        {
            _materialAppService.Adicionar(materialViewModel);
            if (Notifications.HasNotifications())
            {
                ValidarErrosDominio();
                return View(materialViewModel);
            }
            TempData["AlertMessage"] = new List<string>() { "Material cadastrada com sucesso!" };
            TempData["Mensagem"] = "Sucesso";
            return RedirectToAction("Estoque", "Home");
        }

        public ActionResult Edit(Guid id)
        {
            var materialViewModel = _materialAppService.ObterPorId(id);
            if (materialViewModel != null)
                return View(materialViewModel);
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(MaterialViewModel materialViewModel)
        {
            if (ModelState.IsValid)
            {
                _materialAppService.Atualizar(materialViewModel);
                return RedirectToAction("Estoque", "Home");
            }
            return View(materialViewModel);
        }

        public ActionResult Details(Guid id)
        {
            var materialViewModel = _materialAppService.ObterPorId(id);
            if (materialViewModel != null)
                return View(materialViewModel);
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            _materialAppService.Excluir(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CapturarMaterialAutoComplete(string query)
        {
            return Json(_GetMateriais(query), JsonRequestBehavior.AllowGet);
        }

        private List<Autocomplete> _GetMateriais(string query)
        {
            var material = new List<Autocomplete>();

            var results = _materialAppService.RetornarListaPorDescricao(query);

            material.AddRange(results.Select(r => new Autocomplete
            {
                Name = r.Descricao,
                Id = r.Id
            }));
            return material;
        }

        public ActionResult BuscarMaterial()
        {
            return View();
        }

        public ActionResult RetornarBusca(MaterialViewModel materialViewModel)
        {
            var lista = _materialAppService.RetornarListaPorDescricao(materialViewModel.Descricao);
            return PartialView("_ListaDeMaterial", lista);
        }
    }
}