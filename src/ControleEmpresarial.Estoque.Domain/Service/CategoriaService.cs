using System.Collections.Generic;
using ControleEmpresarial.Estoque.Domain.Entities;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Interface.Service;
using ControleEmpresarial.Estoque.Domain.Validation.Categoria;

namespace ControleEmpresarial.Estoque.Domain.Service
{
    public class CategoriaService : ServiceBase<Categoria>, ICategoriaService
    {
        private readonly ICategoriaRepository _repository;
        public CategoriaService(ICategoriaRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Categoria Adicionar(Categoria marca)
        {
            marca.ResultadoValidacao = new CategoriaAptaParaCadastroValidation(_repository).Validate(marca);
            if (PossuiConformidade(marca.ResultadoValidacao))
                _repository.Add(marca);
            return marca;
        }

        public Categoria RetornarPorDescricao(string descricao)
        {
            return _repository.RetornarPorDescricao(descricao);
        }

        public IList<Categoria> RetornarListaPorDescricao(string descricao)
        {
            return _repository.RetornarListaPorDescricao(descricao);
        }
    }
}