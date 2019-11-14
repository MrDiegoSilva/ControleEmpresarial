using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Localidade;
using DomainValidation.Validation;

namespace ControleEmpresarial.Estoque.Domain.Validation.Localidade
{
    public class LocalidadeAptaParaCadastroValidation : Validator<Entities.Localidade>
    {
        public LocalidadeAptaParaCadastroValidation(ILocalidadeRepository repository)
        {
            var localidadeDuplicada = new LocalidadeDeveSerUnicaSpecification(repository);

            base.Add("localidadeDuplicada", new Rule<Entities.Localidade>(localidadeDuplicada, "Localidade já cadastrada!"));
        }
    }
}