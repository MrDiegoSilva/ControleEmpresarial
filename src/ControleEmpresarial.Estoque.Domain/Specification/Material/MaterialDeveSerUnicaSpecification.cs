using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using DomainValidation.Interfaces.Specification;

namespace ControleEmpresarial.Estoque.Domain.Specification.Material
{
    public class MaterialDeveSerUnicaSpecification : ISpecification<Entities.Material>
    {
        private readonly IMaterialRepository _repository;

        public MaterialDeveSerUnicaSpecification(IMaterialRepository repository)
        {
            _repository = repository;
        }

        public bool IsSatisfiedBy(Entities.Material material)
        {
            return _repository.RetornarPorDescricao(material.Descricao) == null;
        }
    }
}