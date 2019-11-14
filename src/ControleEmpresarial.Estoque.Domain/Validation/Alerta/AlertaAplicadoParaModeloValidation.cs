using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Alerta;
using DomainValidation.Interfaces.Validation;
using DomainValidation.Validation;

namespace ControleEmpresarial.Estoque.Domain.Validation.Alerta
{
    public class AlertaAplicadoParaModeloValidation : Validator<Entities.Alerta>
    {
        public AlertaAplicadoParaModeloValidation(IProdutoRepository produtoRepository)
        {
            var alerta = new AlertaAplicadoParaModeloSpecification(produtoRepository);

            base.Add("alertaDuplicado", new Rule<Entities.Alerta>(alerta, "alerta disparado!"));
        }
    }
}