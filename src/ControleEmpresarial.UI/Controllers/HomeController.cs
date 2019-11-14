using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Web.Mvc;
using ControleEmpresarial.Estoque.Application.Interface;
using ControleEmpresarial.UI.Models;

namespace ControleEmpresarial.UI.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;

        public HomeController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Estoque()
        {
            ViewBag.TotalEstoque = await _produtoAppService.ObterTotalProdutosEmEstoque();
            ViewBag.ValorEntrada = await _produtoAppService.ObterTotalEntradaNoEstoque();
            ViewBag.ValorSaida = await _produtoAppService.ObterTotalSaidaNoEstoque();
            return View();
        }

        public ActionResult Vendas()
        {
            return View();
        }

        public ActionResult Acessos()
        {
            return View();
        }

        public async Task<JsonResult> DadosEntradaGraficoEstoque()
        {
            var lista = new List<DataPointViewModel>();
            for (int i = 5; i >= 0; i--)
            {
                var data = DateTime.Now;
                var valorA = await _produtoAppService.ObterTotalEntradaNoEstoquePorPeriodo(data.Month - i, data.Year);
                var valorB = await _produtoAppService.ObterTotalSaidaNoEstoquePorPeriodo(data.Month - i, data.Year);

                data = data.AddMonths(-i);
                var mes = data.ToString("MMMM", new CultureInfo("pt-BR"));

                lista.Add(new DataPointViewModel(mes,valorA,valorB));
            }
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
    }
}