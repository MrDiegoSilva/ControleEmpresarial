using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ControleEmpresarial.Estoque.Application.Interface;
using ControleEmpresarial.Estoque.Application.ViewModel;

namespace ControleEmpresarial.UI.Controllers
{
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly ILocalidadeAppService _localidadeAppService;
        private readonly ISessaoAppService _sessaoAppService;

        public ProdutoController(IProdutoAppService produtoAppService, ILocalidadeAppService localidadeAppService, ISessaoAppService sessaoAppService)
        {
            _produtoAppService = produtoAppService;
            _localidadeAppService = localidadeAppService;
            _sessaoAppService = sessaoAppService;
        }

        #region Buscar Produto

        public ActionResult BuscarProduto()
        {
            CarregarViewBags();
            return View();
        }

        public ActionResult BuscarProdutoPorCodigo(BuscarProdutoViewModel buscarProdutoViewModel)
        {
            var lista = _produtoAppService.BuscarProdutoPorCodigo(buscarProdutoViewModel);
            return PartialView("_ListaDeProdutos", lista);
        }

        public ActionResult BuscarProdutoPorDados(BuscarProdutoViewModel buscarProdutoViewModel)
        {
            var lista = _produtoAppService.BuscarProdutoPorDados(buscarProdutoViewModel);
            return PartialView("_ListaDeProdutos", lista);
        }

        public ActionResult BuscarProdutoPorEspecificacao(BuscarProdutoViewModel buscarProdutoViewModel)
        {
            var lista = _produtoAppService.BuscarProdutoPorEspecificacao(buscarProdutoViewModel);
            return PartialView("_ListaDeProdutos", lista);
        }

        public ActionResult BuscarProdutoPorLocalidade(BuscarProdutoViewModel buscarProdutoViewModel)
        {
            var lista = _produtoAppService.BuscarProdutoPorLocalidade(buscarProdutoViewModel);
            return PartialView("_ListaDeProdutos", lista);
        }

        #endregion

        #region ConferenciaProdutos

        [HttpGet]
        public ActionResult ConferenciaDeProdutos()
        {
            CarregarViewBags();
            return View();
        }

        [HttpPost]
        public ActionResult ConferenciaDeProdutos(BuscarProdutoViewModel buscarProdutoViewModel)
        {
            buscarProdutoViewModel.ProdutosEmEstoqueViewModelsCollection = _produtoAppService.BuscarProdutoPorLocalidade(buscarProdutoViewModel);
            TempData["ListaProdutosEmEstoque"] = buscarProdutoViewModel.ProdutosEmEstoqueViewModelsCollection;
            TempData["ListaProdutosConferidos"] = buscarProdutoViewModel.ProdutosConferidosModelsCollection;
            CarregarViewBags();
            return View(buscarProdutoViewModel);
        }

        [HttpPost]
        public ActionResult RealizarConferencia(BuscarProdutoViewModel buscarProdutoViewModel)
        {
            if (buscarProdutoViewModel == null) return Json(null, JsonRequestBehavior.AllowGet);
            if (string.IsNullOrEmpty(buscarProdutoViewModel.Codigo))
                return Json(null, JsonRequestBehavior.AllowGet);

            buscarProdutoViewModel.ProdutosEmEstoqueViewModelsCollection = (List<ProdutoViewModel>)TempData["ListaProdutosEmEstoque"] ?? new List<ProdutoViewModel>(); TempData.Keep("ListaProdutosEmEstoque");
            buscarProdutoViewModel.ProdutosConferidosModelsCollection = (List<ProdutoViewModel>)TempData["ListaProdutosConferidos"] ?? new List<ProdutoViewModel>(); TempData.Keep("ListaProdutosConferidos");
            var produto = buscarProdutoViewModel.ProdutosEmEstoqueViewModelsCollection.SingleOrDefault(p => p.Codigo.Equals(buscarProdutoViewModel.Codigo));
            if (produto == null) return Json(null, JsonRequestBehavior.AllowGet);
            buscarProdutoViewModel.ProdutosEmEstoqueViewModelsCollection.Remove(produto);
            buscarProdutoViewModel.ProdutosConferidosModelsCollection.Add(produto);
            TempData["ListaProdutosEmEstoque"] = buscarProdutoViewModel.ProdutosEmEstoqueViewModelsCollection;
            TempData["ListaProdutosConferidos"] = buscarProdutoViewModel.ProdutosConferidosModelsCollection;
            return PartialView("_ListaProdutosConferencia", buscarProdutoViewModel);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult RealizarConferenciaManual(string codigo)
        {
            if (string.IsNullOrEmpty(codigo)) return Json(null, JsonRequestBehavior.AllowGet);
            var buscarProdutoViewModel = new BuscarProdutoViewModel();
            buscarProdutoViewModel.ProdutosEmEstoqueViewModelsCollection = (List<ProdutoViewModel>)TempData["ListaProdutosEmEstoque"] ?? new List<ProdutoViewModel>(); TempData.Keep("ListaProdutosEmEstoque");
            buscarProdutoViewModel.ProdutosConferidosModelsCollection = (List<ProdutoViewModel>)TempData["ListaProdutosConferidos"] ?? new List<ProdutoViewModel>(); TempData.Keep("ListaProdutosConferidos");

            var produto = buscarProdutoViewModel.ProdutosEmEstoqueViewModelsCollection.SingleOrDefault(p => p.Codigo.Equals(codigo));
            if (produto != null)
            {
                buscarProdutoViewModel.ProdutosEmEstoqueViewModelsCollection.Remove(produto);
                buscarProdutoViewModel.ProdutosConferidosModelsCollection.Add(produto);
            }
            else
            {
                produto = buscarProdutoViewModel.ProdutosConferidosModelsCollection.SingleOrDefault(p => p.Codigo.Equals(codigo));
                if (produto != null)
                {
                    buscarProdutoViewModel.ProdutosConferidosModelsCollection.Remove(produto);
                    buscarProdutoViewModel.ProdutosEmEstoqueViewModelsCollection.Add(produto);
                }
                else
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
            }
            TempData["ListaProdutosEmEstoque"] = buscarProdutoViewModel.ProdutosEmEstoqueViewModelsCollection;
            TempData["ListaProdutosConferidos"] = buscarProdutoViewModel.ProdutosConferidosModelsCollection;
            return PartialView("_ListaProdutosConferencia", buscarProdutoViewModel);
        }

        #endregion

        #region Movimentação de Produto
        public ActionResult MovimentarProduto(BuscarProdutoViewModel buscarProdutoViewModel)
        {
            CarregarViewBags();
            if (buscarProdutoViewModel != null)
            {
                buscarProdutoViewModel.ProdutosEmEstoqueViewModelsCollection = _produtoAppService.BuscarProdutoPorCodigo(buscarProdutoViewModel);
                return View(buscarProdutoViewModel);
            }
            return View();
        }

        [HttpPost]
        public ActionResult RealizarMovimentacao(Guid? id)
        {
            _produtoAppService.MovimentarProduto(id.Value);
            return RedirectToAction("Estoque", "Home");
        }

        public ActionResult BuscarProdutoPorCodigoMovimentacao(BuscarProdutoViewModel buscarProdutoViewModel)
        {
            var lista = _produtoAppService.BuscarProdutoPorCodigo(buscarProdutoViewModel);
            return PartialView("_ListaProdutosMovimentcao", lista);
        }

        public ActionResult BuscarProdutoPorDadosMovimentacao(BuscarProdutoViewModel buscarProdutoViewModel)
        {
            var lista = _produtoAppService.BuscarProdutoPorDados(buscarProdutoViewModel);
            return PartialView("_ListaProdutosMovimentcao", lista);
        }

        public ActionResult BuscarProdutoPorEspecificacaoMovimentacao(BuscarProdutoViewModel buscarProdutoViewModel)
        {
            var lista = _produtoAppService.BuscarProdutoPorEspecificacao(buscarProdutoViewModel);
            return PartialView("_ListaProdutosMovimentcao", lista);
        }

        public ActionResult BuscarProdutoPorLocalidadeMovimentacao(BuscarProdutoViewModel buscarProdutoViewModel)
        {
            var lista = _produtoAppService.BuscarProdutoPorLocalidade(buscarProdutoViewModel);
            return PartialView("_ListaProdutosMovimentcao", lista);
        }

        #endregion

        public ActionResult Create()
        {
            CarregarViewBags();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProdutoViewModel produtoViewModel)
        {
            _produtoAppService.Adicionar(produtoViewModel);
            if (Notifications.HasNotifications())
            {
                ValidarErrosDominio();
                CarregarViewBags(produtoViewModel);
                return View(produtoViewModel);
            }
            TempData["AlertMessage"] = new List<string>() { "Produto cadastrado com sucesso" };
            TempData["Mensagem"] = "Sucesso";
            return RedirectToAction("Estoque", "Home");
        }

        public ActionResult Edit(Guid id)
        {
            var produtoViewModel = _produtoAppService.ObterPorId(id);
            if (produtoViewModel == null) return HttpNotFound();
            CarregarViewBags(produtoViewModel);
            return View(produtoViewModel);
        }

        [HttpPost]
        public ActionResult Edit(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                _produtoAppService.Atualizar(produtoViewModel);
                return RedirectToAction("Estoque", "Home");
            }
            CarregarViewBags(produtoViewModel);
            return View(produtoViewModel);
        }

        public ActionResult Details(Guid id)
        {
            var produtoViewModel = _produtoAppService.ObterPorId(id);
            if (produtoViewModel != null)
                return View(produtoViewModel);
            return HttpNotFound();
        }

        public ActionResult Delete(Guid id)
        {
            var produtoViewModel = _produtoAppService.ObterPorId(id);
            if (produtoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _produtoAppService.Excluir(id);
            return RedirectToAction("Estoque", "Home");
        }

        [HttpGet]
        public ActionResult Inventario()
        {
            CarregarViewBags();
            return View();
        }

        [HttpPost]
        public ActionResult Inventario(BuscarProdutoViewModel buscarProdutoViewModel)
        {
            buscarProdutoViewModel.ProdutosEmEstoqueViewModelsCollection = _produtoAppService.BuscarProdutoPorLocalidade(buscarProdutoViewModel);
            CarregarViewBags();
            return View(buscarProdutoViewModel);
        }



        private void CarregarViewBags(ProdutoViewModel produtoViewModel = null)
        {
            var listaLocalidade = _localidadeAppService.ObterTodos();
            if (produtoViewModel != null)
            {
                ViewBag.ListaLocalidade = new SelectList(listaLocalidade, "Id", "Descricao", produtoViewModel.Sessao.LocalidadeId);
                var localidade = _sessaoAppService.ObterPorLocalidade(produtoViewModel.Sessao.LocalidadeId);
                ViewBag.ListaSessao = new SelectList(localidade, "Id", "Descricao", produtoViewModel.SessaoId);
            }
            else
            {
                if (listaLocalidade.Any())
                {
                    ViewBag.ListaLocalidade = new SelectList(listaLocalidade, "Id", "Descricao");
                    var sessoes = _sessaoAppService.ObterPorLocalidade(listaLocalidade.First().Id);
                    ViewBag.ListaSessao = new SelectList(sessoes, "Id", "Descricao");
                }
                else
                {
                    ViewBag.ListaLocalidade = new SelectList(listaLocalidade, "Id", "Descricao");
                    ViewBag.ListaSessao = new SelectList(new List<SessaoViewModel>(), "Id", "Descricao");
                }
            }
        }
    }
}