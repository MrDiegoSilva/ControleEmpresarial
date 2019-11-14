using System;
using System.Collections.Generic;
using System.ComponentModel;
using ControleEmpresarial.Estoque.Domain.Entities.Enum;

namespace ControleEmpresarial.Estoque.Application.ViewModel
{
    public class BuscarProdutoViewModel
    {
        public BuscarProdutoViewModel()
        {
            ProdutosEmEstoqueViewModelsCollection = new List<ProdutoViewModel>();
            ProdutosConferidosModelsCollection = new List<ProdutoViewModel>();
        }

        [DisplayName("Modelo")]
        public string Modelo { get; set; }

        [DisplayName("Código")]
        public string Codigo { get; set; }

        [DisplayName("Tamanho do Aro")]
        public int TamanhoAro { get; set; }

        [DisplayName("Tamanho da Ponte")]
        public int TamanhoPonte { get; set; }

        [DisplayName("Comprimento da Haste")]
        public int ComprimentoHaste { get; set; }

        [DisplayName("Marca")]
        public Guid MarcaId { get; set; }

        [DisplayName("Categoria")]
        public Guid CategoriaId { get; set; }

        [DisplayName("Sessão")]
        public Guid SessaoId { get; set; }

        [DisplayName("Local")]
        public Guid LocalidadeId { get; set; }

        [DisplayName("Status do Produto")]
        public StatusDoProduto StatusDoProduto { get; set; }

        public virtual SessaoViewModel SessaoViewModel { get; set; }

        public virtual LocalidadeViewModel LocalidadeViewModel { get; set; }

        public virtual MarcaViewModel Marca { get; set; }

        public virtual CategoriaViewModel Categoria { get; set; }

        public virtual ICollection<ProdutoViewModel> ProdutosEmEstoqueViewModelsCollection { get; set; }

        public virtual ICollection<ProdutoViewModel> ProdutosConferidosModelsCollection { get; set; }

    }
}