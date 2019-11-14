using System.Collections.Generic;
using System.Threading.Tasks;
using ControleEmpresarial.Estoque.Domain.Entities;
using ControleEmpresarial.Estoque.Domain.Entities.Enum;

namespace ControleEmpresarial.Estoque.Domain.Interface.Repository
{
    public interface IAlertaRepository : IRepositoryBase<Alerta>
    {
        Alerta RetornarPorDescricao(string descricao);
        Task<int> VerificarAlertasDisparados();
        IList<Alerta> BuscarAlerta(string descricao, CondicoesDeAlerta condicaoDeAlerta, StatusAlerta statusAlerta);
    }
}