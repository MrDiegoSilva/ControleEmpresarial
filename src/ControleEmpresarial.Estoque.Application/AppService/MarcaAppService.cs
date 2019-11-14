using System;
using System.Collections.Generic;
using AutoMapper;
using ControleEmpresarial.Estoque.Application.Interface;
using ControleEmpresarial.Estoque.Application.ViewModel;
using ControleEmpresarial.Estoque.Data.Interfaces;
using ControleEmpresarial.Estoque.Domain.Entities;
using ControleEmpresarial.Estoque.Domain.Interface.Service;

namespace ControleEmpresarial.Estoque.Application.AppService
{
    public class MarcaAppService : ApplicationService, IMarcaAppService
    {
        private readonly IMapper _mapper;
        private readonly IMarcaService _marcaService;

        public MarcaAppService(IUnitOfWork unitOfWork, IMarcaService marcaService, IMapper mapper) : base(unitOfWork)
        {
            _marcaService = marcaService;
            _mapper = mapper;
        }

        public MarcaViewModel Adicionar(MarcaViewModel marcaViewModel)
        {
            var marca = _mapper.Map<Marca>(marcaViewModel);
            _marcaService.Adicionar(marca);
            Commit();
            return marcaViewModel;
        }

        public MarcaViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<MarcaViewModel>(_marcaService.GetById(id));
        }

        public IEnumerable<MarcaViewModel> ObterTodos(bool @readonly = false)
        {
            return _mapper.Map<IEnumerable<MarcaViewModel>>(_marcaService.GetAll(@readonly));
        }

        public void Atualizar(MarcaViewModel marcaViewModel)
        {
            var marca = _mapper.Map<Marca>(marcaViewModel);
            _marcaService.Update(marca);
            Commit();
        }

        public void Excluir(Guid id)
        {
            var marca = _marcaService.GetById(id);
            _marcaService.Delete(marca);
            Commit();
        }

        public MarcaViewModel RetornarPorDescricao(string marcaDescricao)
        {
            return _mapper.Map<MarcaViewModel>(_marcaService.RetornarPorDescricao(marcaDescricao));
        }

        public IList<MarcaViewModel> RetornarListaPorDescricao(string descricao)
        {
            return _mapper.Map<IList<MarcaViewModel>>(_marcaService.RetornarListaPorDescricao(descricao));
        }
    }
}