using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ControleEmpresarial.Estoque.Application.Interface;
using ControleEmpresarial.Estoque.Application.ViewModel;
using ControleEmpresarial.UI.Models;

namespace ControleEmpresarial.UI.Controllers
{
    public class SessaoController : ControllerBase
    {
        private readonly ISessaoAppService _sessaoAppService;

        public SessaoController(ISessaoAppService sessaoAppService)
        {
            _sessaoAppService = sessaoAppService;
        }


        public ActionResult Create(Guid localidadeId)
        {
            return PartialView("_Create", new SessaoViewModel(localidadeId));
        }

        [HttpPost]
        public ActionResult Create(SessaoViewModel sessaoViewModel)
        {
            if(!ModelState.IsValid) return Json(null, JsonRequestBehavior.AllowGet);
            _sessaoAppService.Adicionar(sessaoViewModel);
            if (Notifications.HasNotifications())
            {
                ValidarErrosDominio();
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            var lista = _sessaoAppService.ObterPorLocalidade(sessaoViewModel.LocalidadeId).ToList();
            return PartialView("_ListaSessao",lista);
        }

        public ActionResult Edit(Guid id)
        {
            var sessaoViewModel = _sessaoAppService.ObterPorId(id);
            if (sessaoViewModel != null)
                return PartialView("_Edit", sessaoViewModel);
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(SessaoViewModel sessaoViewModel)
        {
            if (!ModelState.IsValid) return Json(null, JsonRequestBehavior.AllowGet);
            _sessaoAppService.Atualizar(sessaoViewModel);
            if (Notifications.HasNotifications())
            {
                ValidarErrosDominio();
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            var lista = _sessaoAppService.ObterPorLocalidade(sessaoViewModel.LocalidadeId).ToList();
            return PartialView("_ListaSessao", lista);
        }

        [HttpPost]
        public ActionResult Delete(Guid sessaoId, Guid localidadeId)
        {
            _sessaoAppService.Excluir(sessaoId);
            var lista = _sessaoAppService.ObterPorLocalidade(localidadeId).ToList();
            return PartialView("_ListaSessao", lista);
        }

        public ActionResult CapturarSessaoAutoComplete(string query)
        {
            return Json(_GetSessao(query), JsonRequestBehavior.AllowGet);
        }

        private List<Autocomplete> _GetSessao(string query)
        {
            var sessoes = new List<Autocomplete>();

            var results = _sessaoAppService.RetornarListaPorDescricao(query);

            sessoes.AddRange(results.Select(r => new Autocomplete
            {
                Name = r.Descricao,
                Id = r.Id
            }));
            return sessoes;
        }
        [HttpGet]
        public JsonResult RetornarSessaoDaLocalidade()
        {
            var queryString = Request.QueryString["localidadeId"];
            if (string.IsNullOrEmpty(queryString)) return Json(null, JsonRequestBehavior.AllowGet);
            var localidadeId = Guid.Parse(queryString);
            var lista = _sessaoAppService.ObterPorLocalidade(localidadeId).Select(s => new {s.Id, s.Descricao});
            return Json(lista.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}