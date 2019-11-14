using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Alerta;
using DomainValidation.Validation;

namespace ControleEmpresarial.Estoque.Domain.Validation.Alerta
{
    public class AlertaAplicadoParaTodosOsProdutosValidation : Validator<Entities.Alerta>
    {
        public AlertaAplicadoParaTodosOsProdutosValidation(IProdutoRepository produtoRepository)
        {
            var alerta = new AlertaAplicadoParaTodosOsProdutosSpecification(produtoRepository);

            base.Add("alertaDuplicado", new Rule<Entities.Alerta>(alerta, "alerta disparado!"));
        }
    }
}