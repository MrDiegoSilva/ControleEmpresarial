using System;
using System.Collections.Generic;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Scopes;
using ControleEmpresarial.Estoque.Domain.Validation.Localidade;
using DomainValidation.Validation;

namespace ControleEmpresarial.Estoque.Domain.Entities
{
    public class Localidade
    {
        public Localidade(string descricao, string endereco)
        {
            Id = Guid.NewGuid();
            ValidarDescricao(descricao);
            ValidarEndereco(endereco);
            SessoesCollection = new List<Sessao>();
        }

        protected Localidade()
        {
            
        }

        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
        public string Endereco { get; private set; }
        public virtual ICollection<Sessao> SessoesCollection { get; private set; }
        public ValidationResult ResultadoValidacao { get; set; }

        public bool IsValid(ILocalidadeRepository repository)
        {
            ResultadoValidacao = new LocalidadeAptaParaCadastroValidation(repository).Validate(this);
            return ResultadoValidacao.IsValid;
        }

        private void ValidarEndereco(string endereco)
        {
            if (this.ValidarEnderecooEhValido(endereco))
                this.Endereco = endereco;
        }

        private void ValidarDescricao(string descricao)
        {
            if (this.ValidarDescricaoEhValido(descricao))
                this.Descricao = descricao;
        }
    }
}