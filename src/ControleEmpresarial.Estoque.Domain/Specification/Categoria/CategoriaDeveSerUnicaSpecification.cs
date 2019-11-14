using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using DomainValidation.Interfaces.Specification;

namespace ControleEmpresarial.Estoque.Domain.Specification.Categoria
{
    public class CategoriaDeveSerUnicaSpecification : ISpecification<Entities.Categoria>
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaDeveSerUnicaSpecification(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public bool IsSatisfiedBy(Entities.Categoria categoria)
        {
            return _repository.RetornarPorDescricao(categoria.Descricao) == null;
        }
    }
}