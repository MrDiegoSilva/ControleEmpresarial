using System;
using System.Collections.Generic;
using ControleEmpresarial.Estoque.Application.ViewModel;

namespace ControleEmpresarial.Estoque.Application.Interface
{
    public interface ISessaoAppService
    {
        SessaoViewModel Adicionar(SessaoViewModel sessaoViewModel);

        SessaoViewModel ObterPorId(Guid id);

        IEnumerable<SessaoViewModel> ObterTodos(bool @readonly = false);

        IEnumerable<SessaoViewModel> ObterPorLocalidade(Guid localidadeId);

        void Atualizar(SessaoViewModel sessaoViewModel);

        void Excluir(Guid id);

        SessaoViewModel RetornarPorDescricao(string descricao);

        IList<SessaoViewModel> RetornarListaPorDescricao(string descricao);
    }
}