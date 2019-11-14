using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using DomainValidation.Interfaces.Specification;

namespace ControleEmpresarial.Estoque.Domain.Specification.Marca
{
    public class MarcaDeveSerUnicaSpecification : ISpecification<Entities.Marca>
    {
        private readonly IMarcaRepository _repository;
        public MarcaDeveSerUnicaSpecification(IMarcaRepository repository)
        {
            _repository = repository;
        }
        public bool IsSatisfiedBy(Entities.Marca marca)
        {
            return _repository.RetornarPorDescricao(marca.Descricao) == null;
        }
    }
}