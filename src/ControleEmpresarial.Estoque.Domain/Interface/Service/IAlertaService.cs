using System.Collections.Generic;
using System.Threading.Tasks;
using ControleEmpresarial.Estoque.Domain.Entities;
using ControleEmpresarial.Estoque.Domain.Entities.Enum;

namespace ControleEmpresarial.Estoque.Domain.Interface.Service
{
    public interface IAlertaService : IServiceBase<Alerta>
    {
        IList<Alerta> BuscarAlerta(string descricao, CondicoesDeAlerta condicaoDeAlerta, StatusAlerta statusAlerta);
        Alerta Adicionar(Alerta alerta);
        Alerta RetornarPorDescricao(string descricao);
        Task<int> VerificarAlertas();
        Task<int> VerificarAlertas(Alerta alerta);
        Task<int> VerificarAlertasDisparados();
    }
}