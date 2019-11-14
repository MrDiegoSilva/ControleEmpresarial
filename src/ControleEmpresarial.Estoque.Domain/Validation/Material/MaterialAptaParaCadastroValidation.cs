using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Material;
using DomainValidation.Validation;

namespace ControleEmpresarial.Estoque.Domain.Validation.Material
{
    public class MaterialAptaParaCadastroValidation : Validator<Entities.Material>
    {
        public MaterialAptaParaCadastroValidation(IMaterialRepository repository)
        {
            var materialDuplicada = new MaterialDeveSerUnicaSpecification(repository);

            base.Add("materialDuplicada", new Rule<Entities.Material>(materialDuplicada, "Material já cadastrada!"));
        }
    }
}