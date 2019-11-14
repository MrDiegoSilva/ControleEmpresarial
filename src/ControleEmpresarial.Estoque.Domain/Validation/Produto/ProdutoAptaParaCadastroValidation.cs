using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Produto;
using DomainValidation.Validation;

namespace ControleEmpresarial.Estoque.Domain.Validation.Produto
{
    public class ProdutoAptoParaCadastroValidation : Validator<Entities.Produto>
    {
        public ProdutoAptoParaCadastroValidation(IProdutoRepository repository)
        {
            var produtoDuplicado = new ProdutoDeveSerUnicoSpecification(repository);

            base.Add("produtoDuplicado", new Rule<Entities.Produto>(produtoDuplicado, "Produto já cadastrado!"));
        }
    }
}