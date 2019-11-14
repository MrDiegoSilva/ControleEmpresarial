using System;
using System.Collections.Generic;
using ControleEmpresarial.Estoque.Application.ViewModel;

namespace ControleEmpresarial.Estoque.Application.Interface
{
    public interface ILocalidadeAppService
    {
        LocalidadeViewModel Adicionar(LocalidadeViewModel localidadeViewModel);

        LocalidadeViewModel ObterPorId(Guid id);

        IEnumerable<LocalidadeViewModel> ObterTodos(bool @readonly = false);

        void Atualizar(LocalidadeViewModel localidadeViewModel);

        void Excluir(Guid id);
        LocalidadeViewModel RetornarPorDescricao(string descricao);

        IList<LocalidadeViewModel> RetornarListaPorDescricao(string descricao);
    }
}