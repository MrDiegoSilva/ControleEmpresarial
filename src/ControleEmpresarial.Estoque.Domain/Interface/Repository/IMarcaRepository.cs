using System.Collections.Generic;
using ControleEmpresarial.Estoque.Domain.Entities;

namespace ControleEmpresarial.Estoque.Domain.Interface.Repository
{
    public interface IMarcaRepository : IRepositoryBase<Marca>
    {
        Marca RetornarPorDescricao(string descricao);
        IList<Marca> RetornarListaPorDescricao(string descricao);
    }
}