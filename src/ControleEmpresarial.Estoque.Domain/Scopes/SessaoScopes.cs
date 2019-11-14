using ControleEmpresarial.Core.Domain.ValuesObjects;
using ControleEmpresarial.Estoque.Domain.Entities;

namespace ControleEmpresarial.Estoque.Domain.Scopes
{
    public static class SessaoScopes
    {
        public static bool ValidarDescricaoEhValido(this Sessao localidade, string descricao)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(descricao, "A descrição é obrigatória")
            );
        }
    }
}