using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ControleEmpresarial.Estoque.Application.Interface;
using ControleEmpresarial.Estoque.Application.ViewModel;
using ControleEmpresarial.Estoque.Data.Interfaces;
using ControleEmpresarial.Estoque.Domain.Entities;
using ControleEmpresarial.Estoque.Domain.Entities.Enum;
using ControleEmpresarial.Estoque.Domain.Interface.Service;

namespace ControleEmpresarial.Estoque.Application.AppService
{
    public class ProdutoAppService : ApplicationService, IProdutoAppService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoService _produtoService;
        private readonly IMarcaAppService _marcaAppService;
        private readonly IMaterialAppService _materialAppService;
        private readonly ILocalidadeAppService _localidadeAppService;
        private readonly ICategoriaAppService _categoriaAppService;
        private readonly IAlertaAppService _alertaAppService;

        public ProdutoAppService(IUnitOfWork unitOfWork, IMapper mapper, IProdutoService produtoService, IMarcaAppService marcaAppService, IMaterialAppService materialAppService, IAlertaAppService alertaAppService, ILocalidadeAppService localidadeAppService, ICategoriaAppService categoriaAppService) : base(unitOfWork)
        {
            _mapper = mapper;
            _produtoService = produtoService;
            _marcaAppService = marcaAppService;
            _materialAppService = materialAppService;
            _alertaAppService = alertaAppService;
            _localidadeAppService = localidadeAppService;
            _categoriaAppService = categoriaAppService;
        }

        public ProdutoViewModel Adicionar(ProdutoViewModel produtoViewModel)
        {
            if (produtoViewModel.Duplicar > 0)
            {
                var lista = DuplicarProduto(produtoViewModel);
                foreach (var item in lista)
                {
                    VerificarObjetosFilhos(item);
                    var produto = _mapper.Map<Produto>(item);
                    AdicionarProduto(produto);
                    Commit();
                }
            }
            else
            {
                VerificarObjetosFilhos(produtoViewModel);
                var produto = _mapper.Map<Produto>(produtoViewModel);
                AdicionarProduto(produto);
                Commit();
            }
            VerificarAlerta();
            return produtoViewModel;
        }

        private void AdicionarProduto(Produto produto)
        {
            _produtoService.Adicionar(produto);
        }

        private void VerificarAlerta()
        {
            var result = _alertaAppService.VerificarAlertas();
            if (result.Result > 0)
                Commit();
        }

        public ProdutoViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(_produtoService.GetById(id));
        }

        public IEnumerable<ProdutoViewModel> ObterTodos(bool @readonly = false)
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoService.GetAll(@readonly));
        }

        public void Atualizar(ProdutoViewModel produtoViewModel)
        {
            produtoViewModel = VerificarObjetosFilhosParaAtualizar(produtoViewModel);
            var produto = _mapper.Map<Produto>(produtoViewModel);
            _produtoService.Update(produto);
            Commit();
            var result = _alertaAppService.VerificarAlertas();
            if (result.Result > 0)
                Commit();
        }

        public void Excluir(Guid id)
        {
            var produto = _produtoService.GetById(id);
            _produtoService.Delete(produto);
            Commit();
            var result = _alertaAppService.VerificarAlertas();
            if (result.Result > 0)
                Commit();
        }

        public ICollection<ProdutoViewModel> BuscarProdutoPorCodigo(BuscarProdutoViewModel buscarProdutoViewModel)
        {
            var lista = new List<ProdutoViewModel>();
            if (buscarProdutoViewModel == null) return lista;
            if (!string.IsNullOrEmpty(buscarProdutoViewModel.Codigo))
            {
                var produto = _mapper.Map<ProdutoViewModel>(_produtoService.RetornarPorCodigo(buscarProdutoViewModel.Codigo));
                if (produto != null)
                {
                    lista.Add(produto);
                }
            }
            return lista;
        }

        public ICollection<ProdutoViewModel> BuscarProdutoPorDados(BuscarProdutoViewModel buscarProdutoViewModel)
        {
            var lista = new List<ProdutoViewModel>();
            if (buscarProdutoViewModel == null) return lista;
            var produto = _mapper.Map<IList<ProdutoViewModel>>(_produtoService.BuscarProdutoPorDados(buscarProdutoViewModel.Modelo, buscarProdutoViewModel.MarcaId, buscarProdutoViewModel.CategoriaId));
            if (produto != null)
            {
                lista.AddRange(produto);
            }
            return lista;
        }

        public ICollection<ProdutoViewModel> BuscarProdutoPorEspecificacao(BuscarProdutoViewModel buscarProdutoViewModel)
        {
            var lista = new List<ProdutoViewModel>();
            if (buscarProdutoViewModel == null) return lista;
            var produto = _mapper.Map<IList<ProdutoViewModel>>(_produtoService.BuscarProdutoPorEspecificacao(buscarProdutoViewModel.ComprimentoHaste, buscarProdutoViewModel.TamanhoAro, buscarProdutoViewModel.TamanhoPonte));
            if (produto != null)
            {
                lista.AddRange(produto);
            }
            return lista;
        }

        public ICollection<ProdutoViewModel> BuscarProdutoPorLocalidade(BuscarProdutoViewModel buscarProdutoViewModel)
        {
            var lista = new List<ProdutoViewModel>();
            if (buscarProdutoViewModel == null) return lista;
            var produto = _mapper.Map<IList<ProdutoViewModel>>(_produtoService.BuscarProdutoPorLocalidade(buscarProdutoViewModel.SessaoId, buscarProdutoViewModel.LocalidadeId, buscarProdutoViewModel.StatusDoProduto));
            if (produto != null)
            {
                lista.AddRange(produto);
            }
            return lista;
        }

        public ICollection<ProdutoViewModel> BuscarProdutoPorStatus(BuscarProdutoViewModel buscarProdutoViewModel)
        {
            if (buscarProdutoViewModel != null)
            {
                switch (buscarProdutoViewModel.StatusDoProduto)
                {
                    case StatusDoProduto.EmEstoque: return _mapper.Map<ICollection<ProdutoViewModel>>(_produtoService.RetornarProdutosEmEstoque());
                    case StatusDoProduto.Avariados: return _mapper.Map<ICollection<ProdutoViewModel>>(_produtoService.RetornarProdutosAvariados());
                    case StatusDoProduto.Devolvidos: return _mapper.Map<ICollection<ProdutoViewModel>>(_produtoService.RetornarProdutosDevolvidos());
                    case StatusDoProduto.Vendidos: return _mapper.Map<ICollection<ProdutoViewModel>>(_produtoService.RetornarProdutosVendidos());
                    default: return null;
                }
            }
            return null;
        }

        public async Task<int> ObterTotalProdutosEmEstoque()
        {
            return await _produtoService.ObterTotalProdutosEmEstoque();
        }

        public async Task<decimal> ObterTotalEntradaNoEstoque()
        {
            return await _produtoService.ObterTotalEntradaNoEstoque();
        }

        public async Task<decimal> ObterTotalSaidaNoEstoque()
        {
            return await _produtoService.ObterTotalSaidaNoEstoque();
        }

        public async Task<int> ObterTotalEntradaNoEstoquePorPeriodo(int mes, int ano)
        {
            return await _produtoService.ObterTotalEntradaNoEstoquePorPeriodo(mes, ano);
        }

        public async Task<int> ObterTotalSaidaNoEstoquePorPeriodo(int mes, int ano)
        {
            return await _produtoService.ObterTotalSaidaNoEstoquePorPeriodo(mes, ano);
        }

        public void MovimentarProduto(Guid id)
        {
            _produtoService.MovimentarProduto(id);
            Commit();
        }

        #region VerificarrObjetosRelacionais
        private void VerificarObjetosFilhos(ProdutoViewModel produtoViewModel)
        {
            if (produtoViewModel != null)
            {
                produtoViewModel.Sessao = null;
                if (produtoViewModel.MarcaId == Guid.Empty && produtoViewModel.Marca != null)
                {
                    var marca = _marcaAppService.RetornarPorDescricao(produtoViewModel.Marca.Descricao);
                    if (marca != null)
                    {
                        produtoViewModel.MarcaId = marca.Id;
                        produtoViewModel.Marca = null;
                    }
                    else
                    {
                        produtoViewModel.MarcaId = produtoViewModel.Marca.Id;
                    }
                }
                else
                    produtoViewModel.Marca = null;

                if (produtoViewModel.MaterialId == Guid.Empty && produtoViewModel.Material != null)
                {
                    var material = _materialAppService.RetornarPorDescricao(produtoViewModel.Material.Descricao);
                    if (material != null)
                    {
                        produtoViewModel.MaterialId = material.Id;
                        produtoViewModel.Material = null;
                    }
                    else
                    {
                        produtoViewModel.MaterialId = produtoViewModel.Material.Id;
                    }
                }
                else
                    produtoViewModel.Material = null;

                if (produtoViewModel.CategoriaId == Guid.Empty && produtoViewModel.Categoria != null)
                {
                    var local = _categoriaAppService.RetornarPorDescricao(produtoViewModel.Categoria.Descricao);
                    if (local != null)
                    {
                        produtoViewModel.CategoriaId = local.Id;
                        produtoViewModel.Categoria = null;
                    }
                    else
                    {
                        produtoViewModel.CategoriaId = produtoViewModel.Categoria.Id;
                    }
                }
                else
                    produtoViewModel.Categoria = null;
            }
        }
        private ProdutoViewModel VerificarObjetosFilhosParaAtualizar(ProdutoViewModel produtoViewModel)
        {
            if (produtoViewModel != null)
            {
                produtoViewModel.Sessao = null;
                if (produtoViewModel.MarcaId == Guid.Empty && produtoViewModel.Marca != null)
                {
                    var marca = _marcaAppService.RetornarPorDescricao(produtoViewModel.Marca.Descricao);
                    if (marca != null)
                    {
                        produtoViewModel.MarcaId = marca.Id;
                    }
                    else
                    {
                        _marcaAppService.Adicionar(produtoViewModel.Marca);
                        Commit();
                        produtoViewModel.MarcaId = produtoViewModel.Marca.Id;
                    }
                    produtoViewModel.Marca = null;
                }

                if (produtoViewModel.MaterialId == Guid.Empty && produtoViewModel.Material != null)
                {
                    var material = _materialAppService.RetornarPorDescricao(produtoViewModel.Material.Descricao);
                    if (material != null)
                    {
                        produtoViewModel.MaterialId = material.Id;
                    }
                    else
                    {
                        _materialAppService.Adicionar(produtoViewModel.Material);
                        Commit();
                        produtoViewModel.MaterialId = produtoViewModel.Material.Id;
                    }
                    produtoViewModel.Material = null;
                }

                if (produtoViewModel.CategoriaId == Guid.Empty && produtoViewModel.Categoria != null)
                {
                    var local = _categoriaAppService.RetornarPorDescricao(produtoViewModel.Categoria.Descricao);
                    if (local != null)
                    {
                        produtoViewModel.CategoriaId = local.Id;
                    }
                    else
                    {
                        _categoriaAppService.Adicionar(produtoViewModel.Categoria);
                        Commit();
                        produtoViewModel.CategoriaId = produtoViewModel.Categoria.Id;
                    }
                    produtoViewModel.Categoria = null;
                }
            }
            return produtoViewModel;
        }
        private List<ProdutoViewModel> DuplicarProduto(ProdutoViewModel produtoViewModel)
        {
            var lista = new List<ProdutoViewModel>() { produtoViewModel };
            for (int i = 0; i < produtoViewModel.Duplicar; i++)
            {
                var prod = new ProdutoViewModel()
                {
                    Marca = produtoViewModel.Marca,
                    AlturaLente = produtoViewModel.AlturaLente,
                    Categoria = produtoViewModel.Categoria,
                    CategoriaId = produtoViewModel.CategoriaId,
                    ComprimentoHaste = produtoViewModel.ComprimentoHaste,
                    Cor = produtoViewModel.Cor,
                    Curvatura = produtoViewModel.Curvatura,
                    Descricao = produtoViewModel.Descricao,
                    SessaoId = produtoViewModel.SessaoId,
                    MarcaId = produtoViewModel.MarcaId,
                    Material = produtoViewModel.Material,
                    MaterialId = produtoViewModel.MaterialId,
                    Modelo = produtoViewModel.Modelo,
                    TamanhoAro = produtoViewModel.TamanhoAro,
                    TamanhoPonte = produtoViewModel.TamanhoPonte,
                    ValorCompra = produtoViewModel.ValorCompra,
                    ValorVenda = produtoViewModel.ValorVenda
                };
                lista.Add(prod);
            }
            return lista;
        }
        #endregion
    }
}