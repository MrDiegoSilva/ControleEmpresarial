using System;
using System.Collections.Generic;
using ControleEmpresarial.Estoque.Application.ViewModel;

namespace ControleEmpresarial.Estoque.Application.Interface
{
    public interface IMaterialAppService
    {
        MaterialViewModel Adicionar(MaterialViewModel materialViewModel);

        MaterialViewModel ObterPorId(Guid id);

        IEnumerable<MaterialViewModel> ObterTodos(bool @readonly = false);

        void Atualizar(MaterialViewModel materialViewModel);

        void Excluir(Guid id);
        MaterialViewModel RetornarPorDescricao(string descricao);
        IList<MaterialViewModel> RetornarListaPorDescricao(string query);
    }
}