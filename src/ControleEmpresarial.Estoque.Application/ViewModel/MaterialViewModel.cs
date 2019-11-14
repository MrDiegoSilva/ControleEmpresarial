﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleEmpresarial.Estoque.Application.ViewModel
{
    public class MaterialViewModel
    {
        public MaterialViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A descrição do material é obrigatório!")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        public ICollection<ProdutoViewModel> ProdutoViewModelCollection { get; set; }
    }
}