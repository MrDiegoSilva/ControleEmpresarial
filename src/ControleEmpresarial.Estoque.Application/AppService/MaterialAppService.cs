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
    public class MaterialAppService : ApplicationService, IMaterialAppService
    {
        private readonly IMapper _mapper;
        private readonly IMaterialService _materialService;
        public MaterialAppService(IUnitOfWork unitOfWork, IMapper mapper, IMaterialService materialService) : base(unitOfWork)
        {
            _mapper = mapper;
            _materialService = materialService;
        }

        public MaterialViewModel Adicionar(MaterialViewModel materialViewModel)
        {
            var material = _mapper.Map<Material>(materialViewModel);
            _materialService.Adicionar(material);
            Commit();
            return materialViewModel;
        }

        public MaterialViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<MaterialViewModel>(_materialService.GetById(id));
        }

        public IEnumerable<MaterialViewModel> ObterTodos(bool @readonly = false)
        {
            return _mapper.Map<IEnumerable<MaterialViewModel>>(_materialService.GetAll(@readonly));
        }

        public void Atualizar(MaterialViewModel materialViewModel)
        {
            var material = _mapper.Map<Material>(materialViewModel);
            _materialService.Update(material);
            Commit();
        }

        public void Excluir(Guid id)
        {
            var material = _materialService.GetById(id);
            _materialService.Delete(material);
            Commit();
        }

        public MaterialViewModel RetornarPorDescricao(string descricao)
        {
            return _mapper.Map<MaterialViewModel>(_materialService.RetornarPorDescricao(descricao));
        }

        public IList<MaterialViewModel> RetornarListaPorDescricao(string descricao)
        {
            return _mapper.Map<IList<MaterialViewModel>>(_materialService.RetornarListaPorDescricao(descricao));
        }
    }
}