using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Alerta;
using DomainValidation.Validation;

namespace ControleEmpresarial.Estoque.Domain.Validation.Alerta
{
    public class AlertaAptoParaCadastroValidation : Validator<Entities.Alerta>
    {
        public AlertaAptoParaCadastroValidation(IAlertaRepository repository)
        {
            var alertaDuplicado = new AlertaDeveSerUnicoSpecification(repository);

            base.Add("alertaDuplicado", new Rule<Entities.Alerta>(alertaDuplicado, "Alerta já cadastrado!"));
        }
    }
}