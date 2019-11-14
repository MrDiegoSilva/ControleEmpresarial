using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ControleEmpresarial.Estoque.Application.Interface;
using ControleEmpresarial.Estoque.Application.ViewModel;
using ControleEmpresarial.Estoque.Data.Interfaces;
using ControleEmpresarial.Estoque.Domain.Entities;
using ControleEmpresarial.Estoque.Domain.Interface.Service;

namespace ControleEmpresarial.Estoque.Application.AppService
{
    public class AlertaAppService : ApplicationService, IAlertaAppService
    {
        private readonly IMapper _mapper;
        private readonly IAlertaService _alertaService;
        private readonly IMarcaAppService _marcaAppService;

        public AlertaAppService(IUnitOfWork unitOfWork, IAlertaService alertaService, IMapper mapper, IMarcaAppService marcaAppService) : base(unitOfWork)
        {
            _alertaService = alertaService;
            _mapper = mapper;
            _marcaAppService = marcaAppService;
        }

        public ICollection<AlertaViewModel> BuscarAlerta(AlertaViewModel alertaViewModel)
        {
            var lista = new List<AlertaViewModel>();
            if (alertaViewModel == null) return lista;
            var produto = _mapper.Map<IList<AlertaViewModel>>(_alertaService.BuscarAlerta(alertaViewModel.Descricao, alertaViewModel.CondicaoDeAlerta, alertaViewModel.StatusAlerta));
            if (produto != null)
            {
                lista.AddRange(produto);
            }
            return lista;
        }

        public AlertaViewModel Adicionar(AlertaViewModel alertaViewModel)
        {
            alertaViewModel.CarregarCondicoes();
            var alerta = _mapper.Map<Alerta>(alertaViewModel);
            _alertaService.VerificarAlertas(alerta);
            _alertaService.Adicionar(alerta);
            Commit();
            return alertaViewModel;
        }

        public AlertaViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<AlertaViewModel>(_alertaService.GetById(id));
        }

        public IEnumerable<AlertaViewModel> ObterTodos(bool @readonly = false)
        {
            return _mapper.Map<IEnumerable<AlertaViewModel>>(_alertaService.GetAll(@readonly));
        }

        public void Atualizar(AlertaViewModel alertaViewModel)
        {
            var alerta = _mapper.Map<Alerta>(alertaViewModel);
            _alertaService.VerificarAlertas(alerta);
            _alertaService.Update(alerta);
            Commit();
        }

        public void Excluir(Guid id)
        {
            var alerta = _alertaService.GetById(id);
            _alertaService.VerificarAlertas(alerta);
            _alertaService.Delete(alerta);
            Commit();
        }

        public AlertaViewModel RetornarPorDescricao(string descricao)
        {
            return _mapper.Map<AlertaViewModel>(_alertaService.RetornarPorDescricao(descricao));
        }

        public async Task<int> VerificarAlertas()
        {
            return await _alertaService.VerificarAlertas();
        }

        public async Task<int> VerificarAlertasDisparados()
        {
            return await _alertaService.VerificarAlertasDisparados();
        }

    }
}