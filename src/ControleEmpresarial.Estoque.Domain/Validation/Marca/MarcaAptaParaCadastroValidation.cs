using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Marca;
using DomainValidation.Validation;

namespace ControleEmpresarial.Estoque.Domain.Validation.Marca
{
    public class MarcaAptaParaCadastroValidation : Validator<Entities.Marca>
    {
        public MarcaAptaParaCadastroValidation(IMarcaRepository repository)
        {
            var marcaDuplicada = new MarcaDeveSerUnicaSpecification(repository);

            base.Add("marcaDuplicada", new Rule<Entities.Marca>(marcaDuplicada, "Marca já cadastrada!"));
        }
    }
}