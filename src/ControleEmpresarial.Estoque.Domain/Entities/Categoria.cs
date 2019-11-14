using System;
using System.Collections.Generic;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Scopes;
using ControleEmpresarial.Estoque.Domain.Validation.Categoria;
using DomainValidation.Validation;

namespace ControleEmpresarial.Estoque.Domain.Entities
{
    public class Categoria
    {
        public Categoria(string descricao)
        {
            Id = Guid.NewGuid();
            ProdutosCollection = new List<Produto>();
            ValidarDescricao(descricao);
        }

        protected Categoria()
        {
            
        }

        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
        public ValidationResult ResultadoValidacao { get; set; }
        public virtual ICollection<Produto> ProdutosCollection { get; set; }

        public bool IsValid(ICategoriaRepository repository)
        {
            ResultadoValidacao = new CategoriaAptaParaCadastroValidation(repository).Validate(this);
            return ResultadoValidacao.IsValid;
        }

        private void ValidarDescricao(string descricao)
        {
            if (this.ValidarDescricaoEhValido(descricao))
                this.Descricao = descricao;
        }
    }
}