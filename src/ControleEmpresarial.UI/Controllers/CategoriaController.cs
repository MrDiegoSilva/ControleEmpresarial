using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ControleEmpresarial.Estoque.Application.Interface;
using ControleEmpresarial.Estoque.Application.ViewModel;
using ControleEmpresarial.UI.Models;

namespace ControleEmpresarial.UI.Controllers
{
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaAppService _categoriaAppService;

        public CategoriaController(ICategoriaAppService categoriaAppService)
        {
            _categoriaAppService = categoriaAppService;
        }

        public ActionResult Index()
        {
            return View(_categoriaAppService.ObterTodos(true));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoriaViewModel categoriaViewModel)
        {
            _categoriaAppService.Adicionar(categoriaViewModel);
            if (Notifications.HasNotifications())
            {
                ValidarErrosDominio();
                return View(categoriaViewModel);
            }
            TempData["AlertMessage"] = new List<string>() { "Categoria cadastrada com sucesso!" };
            TempData["Mensagem"] = "Sucesso";
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            var categoriaViewModel = _categoriaAppService.ObterPorId(id);
            if (categoriaViewModel != null)
                return View(categoriaViewModel);
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(CategoriaViewModel categoriaViewModel)
        {
            if (ModelState.IsValid)
            {
                _categoriaAppService.Atualizar(categoriaViewModel);
                return RedirectToAction("Estoque", "Home");
            }
            return View(categoriaViewModel);
        }

        public ActionResult Details(Guid id)
        {
            var categoriaViewModel = _categoriaAppService.ObterPorId(id);
            if (categoriaViewModel != null)
                return View(categoriaViewModel);
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            _categoriaAppService.Excluir(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CapturarCategoriaAutoComplete(string query)
        {
            return Json(_GetCategoria(query), JsonRequestBehavior.AllowGet);
        }

        private List<Autocomplete> _GetCategoria(string query)
        {
            var categoria = new List<Autocomplete>();
            var results = _categoriaAppService.RetornarListaPorDescricao(query);

            categoria.AddRange(results.Select(r => new Autocomplete
            {
                Name = r.Descricao,
                Id = r.Id
            }));
            return categoria;
        }

        public ActionResult BuscarCategoria()
        {
            return View();
        }

        public ActionResult RetornarBusca(CategoriaViewModel categoriaViewModel)
        {
            var lista = _categoriaAppService.RetornarListaPorDescricao(categoriaViewModel.Descricao);
            return PartialView("_ListaDeCategorias", lista);
        }
    }
}