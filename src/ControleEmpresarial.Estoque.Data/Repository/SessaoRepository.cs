using System;
using System.Collections.Generic;
using System.Linq;
using ControleEmpresarial.Estoque.Data.Context;
using ControleEmpresarial.Estoque.Domain.Entities;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;

namespace ControleEmpresarial.Estoque.Data.Repository
{
    public class SessaoRepository : RepositoryBase<Sessao>, ISessaoRepository
    {
        public SessaoRepository(EstoqueContext context) : base(context)
        {
        }

        public Sessao ObterSessaoDaLocalidade(Guid sessaoId, Guid sessaoLocalidadeId)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(s => s.Id == sessaoId && s.LocalidadeId == sessaoLocalidadeId);
        }

        public Sessao RetornarPorDescricao(string descricao)
        {
            throw new NotImplementedException();
        }

        public IList<Sessao> RetornarListaPorDescricao(string descricao)
        {
            return _dbSet.AsNoTracking().Where(s => s.Descricao.Contains(descricao)).OrderBy(s => s.Descricao).ToList();
        }

        public IList<Sessao> ObterPorLocalidade(Guid localidadeId)
        {
            return _dbSet.AsNoTracking().Where(s => s.LocalidadeId == localidadeId).OrderBy(s => s.Descricao).ToList();
        }
    }
}