using System.Collections.Generic;
using ControleEmpresarial.Estoque.Domain.Entities;

namespace ControleEmpresarial.Estoque.Domain.Interface.Service
{
    public interface ILocalidadeService : IServiceBase<Localidade>
    {
        Localidade Adicionar(Localidade localidade);

        Localidade RetornarPorDescricao(string localidadeDescricao);

        IList<Localidade> RetornarListaPorDescricao(string descricao);
    }
}