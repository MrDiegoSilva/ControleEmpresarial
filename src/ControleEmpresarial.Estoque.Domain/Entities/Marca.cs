using System;
using System.Collections.Generic;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Scopes;
using ControleEmpresarial.Estoque.Domain.Validation.Marca;
using DomainValidation.Validation;

namespace ControleEmpresarial.Estoque.Domain.Entities
{
    public class Marca
    {
        public Marca(string descricao)
        {
            Id = Guid.NewGuid();
            ValidarDescricao(descricao);
            ProdutosCollection = new List<Produto>();
        }

        protected Marca()
        {
            
        }

        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
        public virtual ICollection<Produto> ProdutosCollection { get; set; }

        public ValidationResult ResultadoValidacao { get; set; }

        public bool IsValid(IMarcaRepository repository)
        {
            ResultadoValidacao = new MarcaAptaParaCadastroValidation(repository).Validate(this);
            return ResultadoValidacao.IsValid;
        }

        private void ValidarDescricao(string descricao)
        {
            if (this.ValidarDescricaoEhValido(descricao))
                this.Descricao = descricao;
        }
    }
}