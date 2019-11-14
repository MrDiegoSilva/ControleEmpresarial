using System;
using System.Collections.Generic;
using ControleEmpresarial.Estoque.Domain.Entities;
using ControleEmpresarial.Estoque.Domain.Entities.Enum;

namespace ControleEmpresarial.Estoque.Domain.Interface.Repository
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        Produto RetornarPorCodigo(string codigo);
        int TotalDeProdutos();
        int TotalDeProdutosPorModelo(string modelo);
        int TotalDeProdutosPorMarca(string marca);
        int TotalDeProdutosPorValorMaximo(string valorMaximo);
        int TotalDeProdutosPorValorMinimo(string valorMinimo);
        int TotalDeProdutosPorTamanho(string tamanho);
        int TotalDeProdutosPorLocalidade(string local);
        int TotalDeProdutosPorArmazenamento(string armazenamento);
        int TotalDeProdutosPorTempoEmEstoque(string totalDias);
        IList<Produto> BuscarProdutoPorDados(string modelo, Guid marcaId, Guid categoriaId);
        IList<Produto> BuscarProdutoPorEspecificacao(int comprimentoHaste, int tamanhoAro, int tamanhoPonte);
        IList<Produto> BuscarProdutoPorLocalidade(Guid sessaoId, Guid localId, StatusDoProduto status);
        IList<Produto> RetornarProdutosEmEstoque();
        IList<Produto> RetornarProdutosAvariados();
        IList<Produto> RetornarProdutosDevolvidos();
        IList<Produto> RetornarProdutosVendidos();
        decimal ObterTotalEntradaNoEstoque();
        decimal ObterTotalSaidaNoEstoque();
        int ObterTotalEntradaNoEstoquePorPeriodo(int mes, int ano);
        int ObterTotalSaidaNoEstoquePorPeriodo(int mes, int ano);
    }
}