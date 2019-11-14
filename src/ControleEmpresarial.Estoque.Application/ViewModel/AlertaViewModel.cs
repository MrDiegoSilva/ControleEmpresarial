using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ControleEmpresarial.Estoque.Domain.Entities.Enum;

namespace ControleEmpresarial.Estoque.Application.ViewModel
{
    public class AlertaViewModel
    {
        public AlertaViewModel()
        {
            Id = Guid.NewGuid();
            Disparado = false;
        }

        [Key]
        public Guid Id { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Descricao { get; set; }

        [DisplayName("Quantidade")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public int Quantidade { get; set; }

        [DisplayName("Condição")]
        public string ValorCondicao { get; set; }

        [ScaffoldColumn(false)]
        public bool Disparado { get; set; }

        [DisplayName("Condição de Alerta")]
        public CondicoesDeAlerta CondicaoDeAlerta { get; set; }

        [DisplayName("Status do Alerta")]
        public StatusAlerta StatusAlerta { get; set; }

        [DisplayName("Condição 1")]
        public string Condicao1 { get { return SepararCondicao1(); } set{} }

        [DisplayName("Condição 2")]
        public string Condicao2 { get { return SepararCondicao2(); } set { } }

        [DisplayName("Condição  3")]
        public string Condicao3 { get { return SepararCondicao3(); } set { } }

        public void CarregarCondicoes()
        {
            if (!string.IsNullOrEmpty(Condicao2) && !string.IsNullOrEmpty(Condicao3))
                ValorCondicao = $"{Condicao1};{Condicao2};{Condicao3}";
            else
                ValorCondicao = Condicao1;
        }

        private string SepararCondicao1()
        {
            if (string.IsNullOrEmpty(ValorCondicao)) return null;
            var condicoes = ValorCondicao.Split(';');
            return condicoes[0];
        }

        private string SepararCondicao2()
        {
            if (string.IsNullOrEmpty(ValorCondicao)) return null;
            var condicoes = ValorCondicao.Split(';');
            return condicoes[1];
        }

        private string SepararCondicao3()
        {
            if (string.IsNullOrEmpty(ValorCondicao)) return null;
            var condicoes = ValorCondicao.Split(';');
            return condicoes[2];
        }
    }
}
