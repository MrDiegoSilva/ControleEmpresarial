using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleEmpresarial.Estoque.Application.ViewModel
{
    public class SessaoViewModel
    {
        public SessaoViewModel()
        {
            Id = Guid.NewGuid();
            ProdutoViewModelsCollection = new List<ProdutoViewModel>();
        }

        public SessaoViewModel(Guid localidadeId)
        {
            Id = Guid.NewGuid();
            LocalidadeId = localidadeId;
            ProdutoViewModelsCollection = new List<ProdutoViewModel>();
        }

        [Key]
        public Guid Id { get; set; }

        [DisplayName("Localidade")]
        public Guid LocalidadeId { get; set; }

        public string Descricao { get; set; }

        public virtual ICollection<ProdutoViewModel> ProdutoViewModelsCollection { get; set; }
    }
}