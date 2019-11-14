using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControleEmpresarial.Estoque.Domain.Entities;
using ControleEmpresarial.Estoque.Domain.Entities.Enum;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Interface.Service;
using ControleEmpresarial.Estoque.Domain.Validation.Produto;

namespace ControleEmpresarial.Estoque.Domain.Service
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _repository;
        public ProdutoService(IProdutoRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Produto Adicionar(Produto produto)
        {
            produto.ResultadoValidacao = new ProdutoAptoParaCadastroValidation(_repository).Validate(produto);
            if (PossuiConformidade(produto.ResultadoValidacao))
                _repository.Add(produto);
            return produto;
        }

        public Produto RetornarPorCodigo(string codigo)
        {
            return _repository.RetornarPorCodigo(codigo);
        }

        public IList<Produto> BuscarProdutoPorDados(string modelo, Guid marcaId, Guid categoriaId)
        {
            return _repository.BuscarProdutoPorDados(modelo, marcaId,categoriaId);
        }

        public IList<Produto> BuscarProdutoPorEspecificacao(int comprimentoHaste, int tamanhoAro, int tamanhoPonte)
        {
            return _repository.BuscarProdutoPorEspecificacao(comprimentoHaste, tamanhoAro, tamanhoPonte);
        }

        public IList<Produto> BuscarProdutoPorLocalidade(Guid sessaoId, Guid localId, StatusDoProduto status)
        {
            return _repository.BuscarProdutoPorLocalidade(sessaoId, localId, status);
        }

        public IList<Produto> RetornarProdutosEmEstoque()
        {
            return _repository.RetornarProdutosEmEstoque();
        }

        public IList<Produto> RetornarProdutosAvariados()
        {
            return _repository.RetornarProdutosAvariados();
        }

        public IList<Produto> RetornarProdutosDevolvidos()
        {
            return _repository.RetornarProdutosDevolvidos();
        }

        public IList<Produto> RetornarProdutosVendidos()
        {
            return _repository.RetornarProdutosVendidos();
        }

        public Task<int> ObterTotalProdutosEmEstoque()
        {
            return Task.FromResult(_repository.TotalDeProdutos());
        }

        public Task<decimal> ObterTotalEntradaNoEstoque()
        {
            return Task.FromResult(_repository.ObterTotalEntradaNoEstoque());
        }

        public Task<decimal> ObterTotalSaidaNoEstoque()
        {
            return Task.FromResult(_repository.ObterTotalSaidaNoEstoque());
        }

        public Task<int> ObterTotalEntradaNoEstoquePorPeriodo(int mes, int ano)
        {
            return Task.FromResult(_repository.ObterTotalEntradaNoEstoquePorPeriodo(mes, ano));
        }

        public Task<int> ObterTotalSaidaNoEstoquePorPeriodo(int mes, int ano)
        {
            return Task.FromResult(_repository.ObterTotalSaidaNoEstoquePorPeriodo(mes, ano));
        }

        public void MovimentarProduto(Guid id)
        {
            var produto = _repository.GetById(id);
            produto.MovimentarProduto(StatusDoProduto.Vendidos);
            _repository.Update(produto);
        }
    }
}