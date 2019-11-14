using System.Collections.Generic;
using ControleEmpresarial.Estoque.Domain.Entities;

namespace ControleEmpresarial.Estoque.Domain.Interface.Service
{
    public interface ICategoriaService : IServiceBase<Categoria>
    {
        Categoria Adicionar(Categoria marca);
        Categoria RetornarPorDescricao(string descricao);
        IList<Categoria> RetornarListaPorDescricao(string descricao);
    }
}