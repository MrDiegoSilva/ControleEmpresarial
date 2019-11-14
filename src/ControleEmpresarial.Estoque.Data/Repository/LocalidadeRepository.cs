using System.Collections.Generic;
using System.Linq;
using ControleEmpresarial.Estoque.Data.Context;
using ControleEmpresarial.Estoque.Domain.Entities;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;

namespace ControleEmpresarial.Estoque.Data.Repository
{
    public class LocalidadeRepository : RepositoryBase<Localidade>, ILocalidadeRepository
    {
        public LocalidadeRepository(EstoqueContext context) : base(context)
        {
        }

        public Localidade RetornarPorDescricao(string descricao)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(c => c.Descricao.Equals(descricao));
        }

        public IList<Localidade> RetornarListaPorDescricao(string descricao)
        {
            if (!string.IsNullOrEmpty(descricao))
                return _dbSet.AsNoTracking().Where(p => p.Descricao.ToLower().Contains(descricao.ToLower())).OrderBy(p => p.Descricao).ToList();
            return _dbSet.AsNoTracking().OrderBy(p => p.Descricao).ToList();
        }
    }
}