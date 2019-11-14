using System.Collections.Generic;
using ControleEmpresarial.Estoque.Domain.Entities;

namespace ControleEmpresarial.Estoque.Domain.Interface.Service
{
    public interface IMaterialService : IServiceBase<Material>
    {
        Material Adicionar(Material material);
        Material RetornarPorDescricao(string descricao);
        IList<Material> RetornarListaPorDescricao(string descricao);
    }
}