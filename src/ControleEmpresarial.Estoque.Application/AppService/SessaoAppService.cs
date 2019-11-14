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
    public class SessaoAppService : ApplicationService, ISessaoAppService
    {
        private readonly ISessaoService _sessaoService;
        private readonly IMapper _mapper;

        public SessaoAppService(IUnitOfWork unitOfWork, ISessaoService sessaoService, IMapper mapper) : base(unitOfWork)
        {
            _sessaoService = sessaoService;
            _mapper = mapper;
        }

        public SessaoViewModel Adicionar(SessaoViewModel sessaoViewModel)
        {
            var localidade = _mapper.Map<Sessao>(sessaoViewModel);
            _sessaoService.Adicionar(localidade);
            Commit();
            return sessaoViewModel;
        }

        public SessaoViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<SessaoViewModel>(_sessaoService.GetById(id));
        }

        public IEnumerable<SessaoViewModel> ObterTodos(bool @readonly = false)
        {
            return _mapper.Map<IEnumerable<SessaoViewModel>>(_sessaoService.GetAll(@readonly));
        }

        public IEnumerable<SessaoViewModel> ObterPorLocalidade(Guid localidadeId)
        {
            return _mapper.Map<IEnumerable<SessaoViewModel>>(_sessaoService.ObterPorLocalidade(localidadeId));
        }

        public void Atualizar(SessaoViewModel sessaoViewModel)
        {
            var sessao = _mapper.Map<Sessao>(sessaoViewModel);
            _sessaoService.Update(sessao);
            Commit();
        }

        public void Excluir(Guid id)
        {
            var sessao = _sessaoService.GetById(id);
            _sessaoService.Delete(sessao);
            Commit();
        }

        public SessaoViewModel RetornarPorDescricao(string descricao)
        {
            return _mapper.Map<SessaoViewModel>(_sessaoService.RetornarPorDescricao(descricao));
        }

        public IList<SessaoViewModel> RetornarListaPorDescricao(string descricao)
        {
            return _mapper.Map<IList<SessaoViewModel>>(_sessaoService.RetornarListaPorDescricao(descricao));
        }
    }
}