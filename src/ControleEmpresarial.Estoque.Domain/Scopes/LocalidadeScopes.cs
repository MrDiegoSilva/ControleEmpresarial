using ControleEmpresarial.Core.Domain.ValuesObjects;
using ControleEmpresarial.Estoque.Domain.Entities;

namespace ControleEmpresarial.Estoque.Domain.Scopes
{
    public static class LocalidadeScopes
    {
        public static bool ValidarDescricaoEhValido(this Localidade localidade, string descricao)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(descricao, "A descrição é obrigatória")
            );
        }

        public static bool ValidarEnderecooEhValido(this Localidade localidade, string endereco)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(endereco, "A descrição é obrigatória")
            );
        }
    }
}