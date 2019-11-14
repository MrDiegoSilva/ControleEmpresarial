using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Alerta;
using DomainValidation.Validation;

namespace ControleEmpresarial.Estoque.Domain.Validation.Alerta
{
    public class AlertaAplicadoParaLocalidadeValidation : Validator<Entities.Alerta>
    {
        public AlertaAplicadoParaLocalidadeValidation(IProdutoRepository produtoRepository)
        {
            var alerta = new AlertaAplicadoParaLocalidadeSpecification(produtoRepository);

            base.Add("alertaDuplicado", new Rule<Entities.Alerta>(alerta, "alerta disparado!"));
        }
    }
}