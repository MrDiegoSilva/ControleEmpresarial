using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleEmpresarial.Estoque.Data.Context;
using ControleEmpresarial.Estoque.Domain.Entities;
using ControleEmpresarial.Estoque.Domain.Entities.Enum;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;

namespace ControleEmpresarial.Estoque.Data.Repository
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(EstoqueContext context) : base(context)
        {
        }

        public Produto RetornarPorCodigo(string codigo)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(p => p.Codigo.ToLower().Equals(codigo.ToLower()));
        }

        public int TotalDeProdutos()
        {
            return _dbSet.AsNoTracking().Count(p => p.EmEstoque);
        }

        public int TotalDeProdutosPorModelo(string modelo)
        {
            return _dbSet.AsNoTracking().Count(p => p.Descricao.ToLower().Contains(modelo.ToLower()) && p.EmEstoque);
        }

        public int TotalDeProdutosPorMarca(string marca)
        {
            return _dbSet.AsNoTracking().Count(p => p.Marca.Descricao.ToLower().Contains(marca.ToLower()) && p.EmEstoque);
        }

        public int TotalDeProdutosPorValorMaximo(string valorMaximo)
        {
            if (string.IsNullOrEmpty(valorMaximo)) return 0;
            decimal valor = Convert.ToDecimal(valorMaximo);
            return _dbSet.AsNoTracking().Count(p => p.ValorCompra < valor && p.EmEstoque);
        }

        public int TotalDeProdutosPorValorMinimo(string valorMinimo)
        {
            if (string.IsNullOrEmpty(valorMinimo)) return 0;
            decimal valor = Convert.ToDecimal(valorMinimo);
            return _dbSet.AsNoTracking().Count(p => p.ValorCompra > valor && p.EmEstoque);
        }

        public int TotalDeProdutosPorTamanho(string tamanho)
        {
            if (string.IsNullOrEmpty(tamanho)) return 0;
            var array = tamanho.Split(';');
            int ponte = Convert.ToInt32(array[0]);
            int lente = Convert.ToInt32(array[1]);
            int haste = Convert.ToInt32(array[2]);
            return _dbSet.AsNoTracking().Count(p => p.TamanhoPonte <= ponte && p.AlturaLente <= lente && p.ComprimentoHaste <= haste && p.EmEstoque);
        }

        public int TotalDeProdutosPorLocalidade(string local)
        {
            throw new NotImplementedException();
            //return _dbSet.AsNoTracking().Count(p => p.Local.ToLower().Contains(local.ToLower()));
        }

        public int TotalDeProdutosPorArmazenamento(string armazenamento)
        {
            throw new NotImplementedException();
            //return _dbSet.AsNoTracking().Count(p => p.Armazenamento.ToLower().Contains(armazenamento.ToLower()));
        }

        public int TotalDeProdutosPorTempoEmEstoque(string totalDias)
        {
            int total = Convert.ToInt32(totalDias);
            return _dbSet.AsNoTracking().Count(p => p.DataEntrada.Subtract(DateTime.Now).TotalDays > total && p.EmEstoque);
        }

        public IList<Produto> BuscarProdutoPorDados(string modelo, Guid marcaId, Guid categoriaId)
        {
            return _dbSet.AsNoTracking().Where(p => p.Modelo.ToLower().Contains(modelo.ToLower()) || p.MarcaId == marcaId || p.CategoriaId == categoriaId && p.EmEstoque).ToList();
        }

        public IList<Produto> BuscarProdutoPorEspecificacao(int comprimentoHaste, int tamanhoAro, int tamanhoPonte)
        {
            return _dbSet.AsNoTracking().Where(p => p.ComprimentoHaste == comprimentoHaste && p.TamanhoAro == tamanhoAro && p.TamanhoPonte == tamanhoPonte && p.EmEstoque).ToList();
        }

        public IList<Produto> BuscarProdutoPorLocalidade(Guid sessaoId, Guid localId, StatusDoProduto status)
        {
            if (sessaoId == Guid.Empty && localId != Guid.Empty)
            {
                return _dbSet.AsNoTracking().Where(p => p.Sessao.LocalidadeId == localId && p.StatusDoProduto == status).ToList();
            }
            return _dbSet.AsNoTracking().Where(p => p.SessaoId == sessaoId && p.StatusDoProduto == status).ToList();
        }

        public IList<Produto> RetornarProdutosEmEstoque()
        {
            return _dbSet.AsNoTracking().Where(p => p.EmEstoque && p.StatusDoProduto == StatusDoProduto.EmEstoque).ToList();
        }

        public IList<Produto> RetornarProdutosAvariados()
        {
            return _dbSet.AsNoTracking().Where(p => p.StatusDoProduto == StatusDoProduto.Avariados).ToList();
        }

        public IList<Produto> RetornarProdutosDevolvidos()
        {
            return _dbSet.AsNoTracking().Where(p => p.StatusDoProduto == StatusDoProduto.Devolvidos).ToList();
        }

        public IList<Produto> RetornarProdutosVendidos()
        {
            return _dbSet.AsNoTracking().Where(p => !p.EmEstoque && p.StatusDoProduto == StatusDoProduto.Vendidos).ToList();
        }

        public decimal ObterTotalEntradaNoEstoque()
        {
            var data = DateTime.Now;
            var total = _dbSet.AsNoTracking().Where(p => p.DataEntrada.Month == data.Month && p.DataEntrada.Year == data.Year).ToList().Sum(p => p.ValorCompra);
            return total;
        }

        public decimal ObterTotalSaidaNoEstoque()
        {
            var data = DateTime.Now;
            var total = _dbSet.AsNoTracking().Where(p => p.DataMovimentacao.Month == data.Month && p.DataMovimentacao.Year == data.Year && p.StatusDoProduto == StatusDoProduto.Vendidos).ToList().Sum(p => p.ValorVenda);
            return total;
        }

        public int ObterTotalEntradaNoEstoquePorPeriodo(int mes, int ano)
        {
            var total = _dbSet.AsNoTracking().Count(p => p.DataEntrada.Month == mes && p.DataEntrada.Year == ano && p.EmEstoque && p.StatusDoProduto == StatusDoProduto.EmEstoque);
            return total;
        }

        public int ObterTotalSaidaNoEstoquePorPeriodo(int mes, int ano)
        {
            var total = _dbSet.AsNoTracking().Count(p => p.DataMovimentacao.Month == mes && p.DataMovimentacao.Year == ano && !p.EmEstoque && p.StatusDoProduto == StatusDoProduto.Vendidos);
            return total;
        }
    }
}