using System;
using System.Collections.Generic;
using ControleEmpresarial.Estoque.Domain.Entities.Enum;
using ControleEmpresarial.Estoque.Domain.Scopes;
using DomainValidation.Validation;

namespace ControleEmpresarial.Estoque.Domain.Entities
{
    public class Alerta
    {
        public Alerta(string descricao, int quantidade, CondicoesDeAlerta condicao)
        {
            Id = Guid.NewGuid();
            Disparado = false;
            ValidarDescricao(descricao);
            ValidarQuantidade(quantidade);
            CondicaoDeAlerta = condicao;
        }

        protected Alerta()
        {
            
        }

        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
        public int Quantidade { get; private set; }
        public string ValorCondicao { get; private set; }
        public bool Disparado { get; private set; }
        public CondicoesDeAlerta CondicaoDeAlerta { get; private set; }
        public ValidationResult ResultadoValidacao { get; set; }

        public bool IsValid()
        {
            return true;
        }

        private void ValidarQuantidade(int quantidade)
        {
            if (this.ValidarQuantidadeEhValido(quantidade))
                this.Quantidade = quantidade;
        }

        private void ValidarDescricao(string descricao)
        {
            if (this.ValidarDescricaoEhValido(descricao))
                this.Descricao = descricao;
        }

        public void DesativarAlerta()
        {
            this.Disparado = false;
        }

        public void AtivarAlerta()
        {
            this.Disparado = true;
        }
    }
}