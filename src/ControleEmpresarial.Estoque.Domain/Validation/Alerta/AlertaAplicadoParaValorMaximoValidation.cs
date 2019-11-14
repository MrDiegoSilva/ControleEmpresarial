using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Alerta;
using DomainValidation.Validation;

namespace ControleEmpresarial.Estoque.Domain.Validation.Alerta
{
    public class AlertaAplicadoParaValorMaximoValidation : Validator<Entities.Alerta>
    {
        public AlertaAplicadoParaValorMaximoValidation(IProdutoRepository produtoRepository)
        {
            var alerta = new AlertaAplicadoParaValorMaximoSpecification(produtoRepository);

            base.Add("alertaDuplicado", new Rule<Entities.Alerta>(alerta, "alerta disparado!"));
        }
    }
}