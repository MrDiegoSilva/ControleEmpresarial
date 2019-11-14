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
    public class CategoriaAppService : ApplicationService, ICategoriaAppService
    {
        private readonly IMapper _mapper;
        private readonly ICategoriaService _categoriaService;

        public CategoriaAppService(IUnitOfWork unitOfWork, ICategoriaService categoriaService, IMapper mapper) : base(unitOfWork)
        {
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        public CategoriaViewModel Adicionar(CategoriaViewModel categoriaViewModel)
        {
            var categoria = _mapper.Map<Categoria>(categoriaViewModel);
            _categoriaService.Adicionar(categoria);
            Commit();
            return categoriaViewModel;
        }

        public CategoriaViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<CategoriaViewModel>(_categoriaService.GetById(id));
        }

        public IEnumerable<CategoriaViewModel> ObterTodos(bool @readonly = false)
        {
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(_categoriaService.GetAll(@readonly));
        }

        public void Atualizar(CategoriaViewModel categoriaViewModel)
        {
             var categoria = _mapper.Map<Categoria>(categoriaViewModel);
            _categoriaService.Update(categoria);
            Commit();
        }

        public void Excluir(Guid id)
        {
            var categoria = _categoriaService.GetById(id);
            _categoriaService.Delete(categoria);
            Commit();
        }

        public CategoriaViewModel RetornarPorDescricao(string categoriaDescricao)
        {
            return _mapper.Map<CategoriaViewModel>(_categoriaService.RetornarPorDescricao(categoriaDescricao));
        }

        public ICollection<CategoriaViewModel> RetornarListaPorDescricao(string descricao)
        {
            return _mapper.Map<ICollection<CategoriaViewModel>>(_categoriaService.RetornarListaPorDescricao(descricao));
        }
    }
}