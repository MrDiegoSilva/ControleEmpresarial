using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControleEmpresarial.Estoque.Domain.Entities;
using ControleEmpresarial.Estoque.Domain.Entities.Enum;

namespace ControleEmpresarial.Estoque.Domain.Interface.Service
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        Produto Adicionar(Produto produto);
        Produto RetornarPorCodigo(string codigo);
        IList<Produto> BuscarProdutoPorDados(string modelo, Guid marcaId, Guid categoriaId);
        IList<Produto> BuscarProdutoPorEspecificacao(int comprimentoHaste, int tamanhoAro, int tamanhoPonte);
        IList<Produto> BuscarProdutoPorLocalidade(Guid sessaoId, Guid localId, StatusDoProduto status);
        IList<Produto> RetornarProdutosEmEstoque();
        IList<Produto> RetornarProdutosAvariados();
        IList<Produto> RetornarProdutosDevolvidos();
        IList<Produto> RetornarProdutosVendidos();
        Task<int> ObterTotalProdutosEmEstoque();
        Task<decimal> ObterTotalEntradaNoEstoque();
        Task<decimal> ObterTotalSaidaNoEstoque();
        Task<int> ObterTotalEntradaNoEstoquePorPeriodo(int mes, int ano);
        Task<int> ObterTotalSaidaNoEstoquePorPeriodo(int mes, int ano);
        void MovimentarProduto(Guid id);
    }
}