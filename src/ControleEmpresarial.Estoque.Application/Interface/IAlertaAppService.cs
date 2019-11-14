using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControleEmpresarial.Estoque.Application.ViewModel;

namespace ControleEmpresarial.Estoque.Application.Interface
{
    public interface IAlertaAppService
    {
        IEnumerable<AlertaViewModel> ObterTodos(bool @readonly = false);

        ICollection<AlertaViewModel> BuscarAlerta(AlertaViewModel alertaViewModel);

        AlertaViewModel Adicionar(AlertaViewModel alertaViewModel);

        AlertaViewModel ObterPorId(Guid id);

        void Atualizar(AlertaViewModel alertaViewModel);

        void Excluir(Guid id);

        AlertaViewModel RetornarPorDescricao(string descricao);

        Task<int> VerificarAlertas();

        Task<int> VerificarAlertasDisparados();
    }
}