using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using DomainValidation.Interfaces.Specification;

namespace ControleEmpresarial.Estoque.Domain.Specification.Produto
{
    public class ProdutoDeveSerUnicoSpecification : ISpecification<Entities.Produto>
    {
        private readonly IProdutoRepository _repository;

        public ProdutoDeveSerUnicoSpecification(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public bool IsSatisfiedBy(Entities.Produto produto)
        {
            return _repository.RetornarPorCodigo(produto.Codigo) == null;
        }
    }
}