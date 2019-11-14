using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Alerta;
using DomainValidation.Validation;

namespace ControleEmpresarial.Estoque.Domain.Validation.Alerta
{
    public class AlertaAplicadoParaMarcaValidation : Validator<Entities.Alerta>
    {
        public AlertaAplicadoParaMarcaValidation(IProdutoRepository produtoRepository)
        {
            var alerta = new AlertaAplicadoParaMarcaSpecification(produtoRepository);

            base.Add("alertaDuplicado", new Rule<Entities.Alerta>(alerta, "alerta disparado!"));
        }
    }
}