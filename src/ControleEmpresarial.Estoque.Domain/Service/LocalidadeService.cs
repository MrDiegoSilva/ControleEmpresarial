using System.Collections.Generic;
using ControleEmpresarial.Estoque.Domain.Entities;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Interface.Service;
using ControleEmpresarial.Estoque.Domain.Validation.Localidade;

namespace ControleEmpresarial.Estoque.Domain.Service
{
    public class LocalidadeService : ServiceBase<Localidade>, ILocalidadeService
    {
        private readonly ILocalidadeRepository _repository;

        public LocalidadeService(ILocalidadeRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Localidade Adicionar(Localidade localidade)
        {
            localidade.ResultadoValidacao = new LocalidadeAptaParaCadastroValidation(_repository).Validate(localidade);
            if (PossuiConformidade(localidade.ResultadoValidacao))
                _repository.Add(localidade);
            return localidade;
        }

        public Localidade RetornarPorDescricao(string descricao)
        {
            return _repository.RetornarPorDescricao(descricao);
        }

        public IList<Localidade> RetornarListaPorDescricao(string descricao)
        {
            return _repository.RetornarListaPorDescricao(descricao);
        }
    }
}