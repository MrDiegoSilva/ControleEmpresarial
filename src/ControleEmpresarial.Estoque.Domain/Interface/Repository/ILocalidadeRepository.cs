using System.Collections.Generic;
using ControleEmpresarial.Estoque.Domain.Entities;

namespace ControleEmpresarial.Estoque.Domain.Interface.Repository
{
    public interface ILocalidadeRepository : IRepositoryBase<Localidade>
    {
        Localidade RetornarPorDescricao(string localidadeDescricao);
        IList<Localidade> RetornarListaPorDescricao(string descricao);
    }
}