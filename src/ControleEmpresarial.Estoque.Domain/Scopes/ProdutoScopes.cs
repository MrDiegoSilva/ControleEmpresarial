using System;
using ControleEmpresarial.Core.Domain.ValuesObjects;
using ControleEmpresarial.Estoque.Domain.Entities;

namespace ControleEmpresarial.Estoque.Domain.Scopes
{
    public static class ProdutoScopes
    {

        public static bool ValidarComprimentoHasteEhValido(this Produto produto, int comprimento)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertGreaterThanZero(comprimento, "O comprimento da haste é obrigatório!")
            );
        }

        public static bool ValidarCurvaturaEhValido(this Produto produto, int comprimento)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertGreaterThanZero(comprimento, "A curvatura é obrigatório!")
            );
        }

        public static bool ValidarCodigoEhValido(this Produto produto, string codigo)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(codigo, "O código é obrigatório!")
            );
        }

        public static bool ValidarTamanhoAroEhValido(this Produto produto, int tamanhoAro)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertGreaterThanZero(tamanhoAro, "O tamanho do aro é obrigatório!")
            );
        }

        public static bool ValidarTamanhoPonteEhValido(this Produto produto, int tamanhoPonte)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertGreaterThanZero(tamanhoPonte, "O tamanho da ponte é obrigatório!")
            );
        }

        public static bool ValidarCorEhValido(this Produto produto, string cor)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(cor, "A cor é obrigatória!")
            );
        }

        public static bool ValidarDescricaoEhValido(this Produto produto, string descricao)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(descricao, "A descricao é obrigatória!")
            );
        }

        public static bool ValidarModeloEhValido(this Produto produto, string modelo)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(modelo, "O modelo é obrigatória!")
            );
        }

        public static bool ValidarMaterialEhValido(this Produto produto, Guid materialId)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertGuidIsValid(materialId, "O material é obrigatório!")
            );
        }

        public static bool ValidarMarcaEhValido(this Produto produto, Guid marcaId)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertGuidIsValid(marcaId, "A marca é obrigatória!")
            );
        }

        public static bool ValidarCategoriaEhValido(this Produto produto, Guid categoriaId)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertGuidIsValid(categoriaId, "A categoria é obrigatória!")
            );
        }

        public static bool ValidarSessaoEhValido(this Produto produto, Guid localidadeId)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertGuidIsValid(localidadeId, "A localidade é obrigatória!")
            );
        }
    }
}