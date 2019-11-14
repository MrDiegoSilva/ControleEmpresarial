using System.Collections.Generic;
using System.Linq;
using ControleEmpresarial.Estoque.Data.Context;
using ControleEmpresarial.Estoque.Domain.Entities;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;

namespace ControleEmpresarial.Estoque.Data.Repository
{
    public class MaterialRepository : RepositoryBase<Material>, IMaterialRepository
    {
        public MaterialRepository(EstoqueContext context) : base(context)
        {
        }

        public Material RetornarPorDescricao(string descricao)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(m => m.Descricao.Equals(descricao));
        }

        public IList<Material> RetornarListaPorDescricao(string descricao)
        {
            if (!string.IsNullOrEmpty(descricao))
                return _dbSet.AsNoTracking().Where(p => p.Descricao.ToLower().Contains(descricao.ToLower())).OrderBy(p => p.Descricao).ToList();
            return _dbSet.AsNoTracking().OrderBy(p => p.Descricao).ToList();
        }
    }
}