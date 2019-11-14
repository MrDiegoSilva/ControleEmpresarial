using System;
using System.Collections.Generic;
using System.ComponentModel;
using ControleEmpresarial.Estoque.Domain.Entities.Enum;

namespace ControleEmpresarial.Estoque.Application.ViewModel
{
    public class ConferenciaEstoqueViewModel
    {
        public ConferenciaEstoqueViewModel()
        {
            ProdutosEntradaViewModelsCollection = new List<ProdutoViewModel>();
            ProdutosSaidaViewModelsCollection = new List<ProdutoViewModel>();
        }
        [DisplayName("Status do Produto")]
        public StatusDoProduto StatusDoProduto { get; set; }

        public virtual ICollection<ProdutoViewModel> ProdutosEntradaViewModelsCollection { get; set; }

        public virtual ICollection<ProdutoViewModel> ProdutosSaidaViewModelsCollection { get; set; }
    }
}