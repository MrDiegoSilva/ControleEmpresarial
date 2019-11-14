using ControleEmpresarial.Core.Domain.ValuesObjects;
using ControleEmpresarial.Estoque.Domain.Entities;

namespace ControleEmpresarial.Estoque.Domain.Scopes
{
    public static class AlertaScopes
    {
        public static bool ValidarDescricaoEhValido(this Alerta alerta, string descricao)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(descricao, "A descrição é obrigatória")
            );
        }

        public static bool ValidarQuantidadeEhValido(this Alerta alerta, int quantidade)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertGreaterThanZero(quantidade, "A quantidade precisa ser maior que zero!")
            );
        }
    }
}