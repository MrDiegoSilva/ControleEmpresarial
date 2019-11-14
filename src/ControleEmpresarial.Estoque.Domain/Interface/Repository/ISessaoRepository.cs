using System;
using System.Collections.Generic;
using ControleEmpresarial.Estoque.Domain.Entities;

namespace ControleEmpresarial.Estoque.Domain.Interface.Repository
{
    public interface ISessaoRepository : IRepositoryBase<Sessao>
    {
        Sessao ObterSessaoDaLocalidade(Guid sessaoId, Guid sessaoLocalidadeId);

        Sessao RetornarPorDescricao(string descricao);

        IList<Sessao> RetornarListaPorDescricao(string descricao);

        IList<Sessao> ObterPorLocalidade(Guid localidadeId);
    }
}