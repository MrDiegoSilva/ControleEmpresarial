using System.Collections.Generic;
using ControleEmpresarial.Estoque.Domain.Entities;

namespace ControleEmpresarial.Estoque.Domain.Interface.Repository
{
    public interface ICategoriaRepository : IRepositoryBase<Categoria>
    {
        Categoria RetornarPorDescricao(string descricao);
        IList<Categoria> RetornarListaPorDescricao(string descricao);
    }
}