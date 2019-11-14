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
    public class LocalidadeAppService : ApplicationService, ILocalidadeAppService
    {
        private readonly IMapper _mapper;
        private readonly ILocalidadeService _service;

        public LocalidadeAppService(IUnitOfWork unitOfWork, ILocalidadeService service, IMapper mapper) : base(unitOfWork)
        {
            _service = service;
            _mapper = mapper;
        }

        public LocalidadeViewModel Adicionar(LocalidadeViewModel localidadeViewModel)
        {
            var localidade = _mapper.Map<Localidade>(localidadeViewModel);
            _service.Adicionar(localidade);
            Commit();
            return localidadeViewModel;
        }

        public LocalidadeViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<LocalidadeViewModel>(_service.GetById(id));
        }

        public IEnumerable<LocalidadeViewModel> ObterTodos(bool @readonly = false)
        {
            return _mapper.Map<IEnumerable<LocalidadeViewModel>>(_service.GetAll(@readonly));
        }

        public void Atualizar(LocalidadeViewModel localidadeViewModel)
        {
            var localidade = _mapper.Map<Localidade>(localidadeViewModel);
            _service.Update(localidade);
            Commit();
        }

        public void Excluir(Guid id)
        {
            var localidade = _service.GetById(id);
            _service.Delete(localidade);
            Commit();
        }

        public LocalidadeViewModel RetornarPorDescricao(string descricao)
        {
            return _mapper.Map<LocalidadeViewModel>(_service.RetornarPorDescricao(descricao));
        }

        public IList<LocalidadeViewModel> RetornarListaPorDescricao(string descricao)
        {
            return _mapper.Map<IList<LocalidadeViewModel>>(_service.RetornarListaPorDescricao(descricao));
        }
    }
}