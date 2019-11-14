using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ControleEmpresarial.Estoque.Domain.Entities.Enum;

namespace ControleEmpresarial.Estoque.Application.ViewModel
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {
            Id = Guid.NewGuid();
            EmEstoque = true;
            DataEntrada = DateTime.Now;
            DataMovimentacao = DateTime.Now;
            Codigo = Id.ToString();
            StatusDoProduto = StatusDoProduto.EmEstoque;
        }

        [Key]
        public Guid Id { get; set; }

        [DisplayName("Marca")]
        public Guid MarcaId { get; set; }

        [DisplayName("Material")]
        public Guid MaterialId { get; set; }

        [DisplayName("Categoria")]
        public Guid CategoriaId { get; set; }

        [DisplayName("Sessao")]
        [Required(ErrorMessage = "A sessão do produto é obrigatório!")]
        public Guid SessaoId { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "A Descricao do produto é obrigatório!")]
        public string Descricao { get; set; }

        [DisplayName("Modelo")]
        [Required(ErrorMessage = "O Modelo do produto é obrigatório!")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O código do produto é obrigatório!")]
        [DisplayName("Código")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "A cor do produto é obrigatório!")]
        [DisplayName("Cor")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "O tamanho do aro é obrigatório!")]
        [DisplayName("Tamanho do Aro")]
        public int TamanhoAro { get; set; }

        [Required(ErrorMessage = "O tamanho da ponte é obrigatório!")]
        [DisplayName("Tamanho da Ponte")]
        public int TamanhoPonte { get; set; }

        [Required(ErrorMessage = "O comprimento da Haste é obrigatório!")]
        [DisplayName("Comprimento da Haste")]
        public int ComprimentoHaste { get; set; }

        [Required(ErrorMessage = "A curvatura do produto é obrigatório!")]
        [DisplayName("Curvatura")]
        public int Curvatura { get; set; }

        [Required(ErrorMessage = "A altura da lente é obrigatório!")]
        [DisplayName("Altura da Lente")]
        public int AlturaLente { get; set; }

        [Required(ErrorMessage = "O valor de compra do produto é obrigatório!")]
        [DisplayName("Valor de Compra")]
        public decimal ValorCompra { get; set; }

        [DisplayName("Valor de Venda")]
        public decimal ValorVenda { get; set; }

        [DisplayName("Status Do Produto")]
        public StatusDoProduto StatusDoProduto { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataEntrada { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataMovimentacao { get; set; }

        [ScaffoldColumn(false)]
        public bool EmEstoque { get; set; }

        [DisplayName("Quantos produtos deseja duplicar apartir deste?")]
        public int Duplicar { get; set; }

        public virtual List<Guid> ListaSessoes { get; set; } 

        public virtual MarcaViewModel Marca { get; set; }
        public virtual MaterialViewModel Material { get; set; }
        public virtual CategoriaViewModel Categoria { get; set; }
        public virtual SessaoViewModel Sessao { get; set; }
    }
}