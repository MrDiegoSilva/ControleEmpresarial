using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControleEmpresarial.Estoque.Application.ViewModel;

namespace ControleEmpresarial.Estoque.Application.Interface
{
    public interface IProdutoAppService
    {
        ProdutoViewModel Adicionar(ProdutoViewModel produtoViewModel);

        ProdutoViewModel ObterPorId(Guid id);

        IEnumerable<ProdutoViewModel> ObterTodos(bool @readonly = false);

        void Atualizar(ProdutoViewModel produtoViewModel);

        void Excluir(Guid id);

        ICollection<ProdutoViewModel> BuscarProdutoPorCodigo(BuscarProdutoViewModel buscarProdutoViewModel);
        ICollection<ProdutoViewModel> BuscarProdutoPorDados(BuscarProdutoViewModel buscarProdutoViewModel);
        ICollection<ProdutoViewModel> BuscarProdutoPorEspecificacao(BuscarProdutoViewModel buscarProdutoViewModel);
        ICollection<ProdutoViewModel> BuscarProdutoPorLocalidade(BuscarProdutoViewModel buscarProdutoViewModel);
        ICollection<ProdutoViewModel> BuscarProdutoPorStatus(BuscarProdutoViewModel buscarProdutoViewModel);

        Task<int> ObterTotalProdutosEmEstoque();
        Task<decimal> ObterTotalEntradaNoEstoque();
        Task<decimal> ObterTotalSaidaNoEstoque();
        Task<int> ObterTotalEntradaNoEstoquePorPeriodo(int mes, int ano);
        Task<int> ObterTotalSaidaNoEstoquePorPeriodo(int mes, int ano);
        void MovimentarProduto(Guid id);
    }
}