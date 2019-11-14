using System.Collections.Generic;
using ControleEmpresarial.Estoque.Domain.Entities;

namespace ControleEmpresarial.Estoque.Domain.Interface.Service
{
    public interface IMarcaService : IServiceBase<Marca>
    {
        Marca Adicionar(Marca marca);
        Marca RetornarPorDescricao(string descricao);
        IList<Marca> RetornarListaPorDescricao(string descricao);
    }
}