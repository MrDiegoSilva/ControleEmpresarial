using System;
using System.Collections.Generic;
using ControleEmpresarial.Estoque.Domain.Entities;

namespace ControleEmpresarial.Estoque.Domain.Interface.Service
{
    public interface ISessaoService : IServiceBase<Sessao>
    {
        Sessao Adicionar(Sessao sessao);

        Sessao RetornarPorDescricao(string descricao);

        IList<Sessao> RetornarListaPorDescricao(string descricao);

        IList<Sessao> ObterPorLocalidade(Guid localidadeId);
    }
}