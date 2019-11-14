using System;
using System.Collections.Generic;
using ControleEmpresarial.Estoque.Domain.Scopes;
using DomainValidation.Validation;

namespace ControleEmpresarial.Estoque.Domain.Entities
{
    public class Sessao
    {
        public Sessao(string descricao)
        {
            Id = Guid.NewGuid();
            ValidarDescricao(descricao);
            ProdutosCollection = new List<Produto>();
        }

        protected Sessao()
        {

        }

        public Guid Id { get; private set; }
        public Guid LocalidadeId { get; private set; }
        public string Descricao { get; private set; }
        public virtual Localidade Localidade { get; private set; }
        public virtual ICollection<Produto> ProdutosCollection { get; set; }
        public ValidationResult ResultadoValidacao { get; set; }

        //public bool IsValid(ILocalidadeRepository repository)
        //{
        //    ResultadoValidacao = new LocalidadeAptaParaCadastroValidation(repository).Validate(this);
        //    return ResultadoValidacao.IsValid;
        //}

        private void ValidarDescricao(string descricao)
        {
            if (this.ValidarDescricaoEhValido(descricao))
                this.Descricao = descricao;
        }
    }
}