using System.Collections.Generic;
using ControleEmpresarial.Estoque.Domain.Entities;

namespace ControleEmpresarial.Estoque.Domain.Interface.Repository
{
    public interface IMaterialRepository : IRepositoryBase<Material>
    {
        Material RetornarPorDescricao(string descricao);
        IList<Material> RetornarListaPorDescricao(string descricao);
    }
}