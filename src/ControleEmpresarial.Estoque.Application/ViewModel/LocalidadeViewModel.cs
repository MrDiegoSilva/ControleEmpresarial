using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleEmpresarial.Estoque.Application.ViewModel
{
    public class LocalidadeViewModel
    {
        public LocalidadeViewModel()
        {
            Id = Guid.NewGuid();
            SessoesCollection = new List<SessaoViewModel>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A descrição da localidade é obrigatório!")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }


        [Required(ErrorMessage = "O endereço da localidade é obrigatório!")]
        [DisplayName("Endereco")]
        public string Endereco { get; set; }

        public ICollection<SessaoViewModel> SessoesCollection { get; set; }
    }
}