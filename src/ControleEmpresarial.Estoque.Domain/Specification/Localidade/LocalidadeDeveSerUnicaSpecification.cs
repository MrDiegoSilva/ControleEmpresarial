using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using DomainValidation.Interfaces.Specification;

namespace ControleEmpresarial.Estoque.Domain.Specification.Localidade
{
    public class LocalidadeDeveSerUnicaSpecification : ISpecification<Entities.Localidade>
    {
        private readonly ILocalidadeRepository _repository;

        public LocalidadeDeveSerUnicaSpecification(ILocalidadeRepository repository)
        {
            _repository = repository;
        }

        public bool IsSatisfiedBy(Entities.Localidade localidade)
        {
            return _repository.RetornarPorDescricao(localidade.Descricao) == null;
        }
    }
}