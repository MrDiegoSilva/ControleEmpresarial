using System;
using System.Collections.Generic;
using ControleEmpresarial.Estoque.Application.ViewModel;

namespace ControleEmpresarial.Estoque.Application.Interface
{
    public interface ICategoriaAppService
    {
        CategoriaViewModel Adicionar(CategoriaViewModel categoriaViewModel);

        CategoriaViewModel ObterPorId(Guid id);

        IEnumerable<CategoriaViewModel> ObterTodos(bool @readonly = false);

        void Atualizar(CategoriaViewModel categoriaViewModel);

        void Excluir(Guid id);
        CategoriaViewModel RetornarPorDescricao(string categoriaDescricao);
        ICollection<CategoriaViewModel> RetornarListaPorDescricao(string descricao);
    }
}