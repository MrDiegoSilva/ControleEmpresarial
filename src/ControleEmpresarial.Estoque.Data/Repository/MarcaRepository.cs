using System.Collections.Generic;
using System.Linq;
using ControleEmpresarial.Estoque.Data.Context;
using ControleEmpresarial.Estoque.Domain.Entities;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;

namespace ControleEmpresarial.Estoque.Data.Repository
{
    public class MarcaRepository : RepositoryBase<Marca>, IMarcaRepository
    {
        public MarcaRepository(EstoqueContext context) : base(context)
        {
        }

        public Marca RetornarPorDescricao(string descricao)
        {
            return _dbSet.FirstOrDefault(m => m.Descricao.Equals(descricao));
        }

        public IList<Marca> RetornarListaPorDescricao(string descricao)
        {
            if (!string.IsNullOrEmpty(descricao))
                return _dbSet.AsNoTracking().Where(p => p.Descricao.ToLower().Contains(descricao.ToLower())).OrderBy(p => p.Descricao).ToList();
            return _dbSet.AsNoTracking().OrderBy(p => p.Descricao).ToList();
        }
    }
}