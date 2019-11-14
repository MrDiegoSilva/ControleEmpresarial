using System;
using System.Collections.Generic;
using ControleEmpresarial.Estoque.Application.ViewModel;

namespace ControleEmpresarial.Estoque.Application.Interface
{
    public interface IMarcaAppService
    {
        MarcaViewModel Adicionar(MarcaViewModel marcaViewModel);

        MarcaViewModel ObterPorId(Guid id);

        IEnumerable<MarcaViewModel> ObterTodos(bool @readonly = false);

        void Atualizar(MarcaViewModel marcaViewModel);

        void Excluir(Guid id);
        MarcaViewModel RetornarPorDescricao(string marcaDescricao);
        IList<MarcaViewModel> RetornarListaPorDescricao(string query);
    }
}