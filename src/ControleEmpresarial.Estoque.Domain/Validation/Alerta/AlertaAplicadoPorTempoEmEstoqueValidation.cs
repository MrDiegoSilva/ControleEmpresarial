using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Alerta;
using DomainValidation.Validation;

namespace ControleEmpresarial.Estoque.Domain.Validation.Alerta
{
    public class AlertaAplicadoPorTempoEmEstoqueValidation : Validator<Entities.Alerta>
    {
        public AlertaAplicadoPorTempoEmEstoqueValidation(IProdutoRepository produtoRepository)
        {
            var alerta = new AlertaAplicadoPorTempoEmEstoqueSpecification(produtoRepository);

            base.Add("alertaDuplicado", new Rule<Entities.Alerta>(alerta, "alerta disparado!"));
        }
    }
}