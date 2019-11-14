using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Alerta;
using DomainValidation.Validation;

namespace ControleEmpresarial.Estoque.Domain.Validation.Alerta
{
    public class AlertaAplicadoParaArmazenamentoValidation : Validator<Entities.Alerta>
    {
        public AlertaAplicadoParaArmazenamentoValidation(IProdutoRepository produtoRepository)
        {
            var alerta = new AlertaAplicadoParaArmazenamentoSpecification(produtoRepository);

            base.Add("alertaDuplicado", new Rule<Entities.Alerta>(alerta, "alerta disparado!"));
        }
    }
}