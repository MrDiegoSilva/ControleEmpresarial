using ControleEmpresarial.Core.Domain.ValuesObjects;
using ControleEmpresarial.Estoque.Domain.Entities;

namespace ControleEmpresarial.Estoque.Domain.Scopes
{
    public static class CategoriaScopes
    {
        public static bool ValidarDescricaoEhValido(this Categoria categoria, string descricao)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(descricao, "A descrição é obrigatória")
            );
        }
    }
}