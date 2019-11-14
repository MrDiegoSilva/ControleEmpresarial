using System;
using System.Collections.Generic;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Scopes;
using ControleEmpresarial.Estoque.Domain.Validation.Material;
using DomainValidation.Validation;

namespace ControleEmpresarial.Estoque.Domain.Entities
{
    public class Material
    {
        public Material(string descricao)
        {
            Id = Guid.NewGuid();
            ProdutosCollection = new List<Produto>();
            ValidarDescricao(descricao);
        }

        protected Material()
        {
            
        }

        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
        public ValidationResult ResultadoValidacao { get; set; }
        public virtual ICollection<Produto> ProdutosCollection { get; set; }

        public bool IsValid(IMaterialRepository repository)
        {
            ResultadoValidacao = new MaterialAptaParaCadastroValidation(repository).Validate(this);
            return ResultadoValidacao.IsValid;
        }

        private void ValidarDescricao(string descricao)
        {
            if (this.ValidarDescricaoEhValido(descricao))
                this.Descricao = descricao;
        }
    }
}