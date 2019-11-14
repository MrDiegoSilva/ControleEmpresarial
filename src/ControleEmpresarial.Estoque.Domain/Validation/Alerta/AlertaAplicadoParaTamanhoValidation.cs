using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Alerta;
using DomainValidation.Validation;

namespace ControleEmpresarial.Estoque.Domain.Validation.Alerta
{
    public class AlertaAplicadoParaTamanhoValidation : Validator<Entities.Alerta>
    {
        public AlertaAplicadoParaTamanhoValidation(IProdutoRepository produtoRepository)
        {
            var alerta = new AlertaAplicadoParaTamanhoSpecification(produtoRepository);

            base.Add("alertaDuplicado", new Rule<Entities.Alerta>(alerta, "alerta disparado!"));
        }
    }
}