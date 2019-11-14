using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Alerta;
using DomainValidation.Validation;

namespace ControleEmpresarial.Estoque.Domain.Validation.Alerta
{
    public class AlertaAplicadoParaValorMinimoValidation : Validator<Entities.Alerta>
    {
        public AlertaAplicadoParaValorMinimoValidation(IProdutoRepository produtoRepository)
        {
            var alerta = new AlertaAplicadoParaValorMinimoSpecification(produtoRepository);

            base.Add("alertaDuplicado", new Rule<Entities.Alerta>(alerta, "alerta disparado!"));
        }
    }
}