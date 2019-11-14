using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Categoria;
using DomainValidation.Validation;

namespace ControleEmpresarial.Estoque.Domain.Validation.Categoria
{
    public class CategoriaAptaParaCadastroValidation : Validator<Entities.Categoria>
    {
        public CategoriaAptaParaCadastroValidation(ICategoriaRepository repository)
        {
            var categoriaDuplicada = new CategoriaDeveSerUnicaSpecification(repository);

            base.Add("categoriaDuplicada", new Rule<Entities.Categoria>(categoriaDuplicada, "Categoria já cadastrada!"));
        }
    }
}