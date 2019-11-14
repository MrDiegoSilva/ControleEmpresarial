using System;
using ControleEmpresarial.Estoque.Domain.Entities.Enum;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Scopes;
using ControleEmpresarial.Estoque.Domain.Validation.Produto;
using DomainValidation.Validation;

namespace ControleEmpresarial.Estoque.Domain.Entities
{
    public class Produto
    {
        public Produto(Guid marcaId, Guid materialId, Guid categoriaId, Guid sessaoId, string descricao, string codigo, string modelo, string cor, int tamanhoAro, int tamanhoPonte, int comprimentoHaste, int curvatura, int alturaLente, decimal valorCompra, decimal valorVenda, DateTime dataEntrada, DateTime dataMovimentacao, bool emEstoque, StatusDoProduto status)
        {
            Id = Guid.NewGuid();
            ValidarMarca(marcaId);
            ValidarMaterial(materialId);
            ValidarCategoria(categoriaId);
            ValidarSessao(sessaoId);
            ValidarCodigo(codigo);
            ValidarCor(cor);
            ValidarComprimentoHaste(comprimentoHaste);
            ValidarTamanhoAro(tamanhoAro);
            ValidarTamanhoPonte(tamanhoPonte);
            ValidarCurvatura(curvatura);
            ValidarDescricao(descricao);
            ValidarModelo(modelo);
            AlturaLente = alturaLente;
            ValorCompra = valorCompra;
            ValorVenda = valorVenda;
            DataEntrada = dataEntrada;
            DataMovimentacao = dataMovimentacao;
            EmEstoque = emEstoque;
            StatusDoProduto = status;
        }

        protected Produto()
        {
            
        }

        public Guid Id { get; private set; }

        public Guid MarcaId { get; private set; }

        public Guid MaterialId { get; private set; }

        public Guid CategoriaId { get; private set; }

        public Guid SessaoId { get; private set; }

        public string Descricao { get; private set; }

        public string Modelo { get; private set; }

        public string Codigo { get; private set; }

        public string Cor { get; private set; }

        public int TamanhoAro { get; private set; }

        public int TamanhoPonte { get; private set; }

        public int ComprimentoHaste { get; private set; }

        public int Curvatura { get; private set; }

        public int AlturaLente { get; private set; }

        public decimal ValorCompra { get; private set; }

        public decimal ValorVenda { get; private set; }

        public DateTime DataEntrada { get; private set; }

        public DateTime DataMovimentacao { get; private set; }

        public bool EmEstoque { get; private set; }

        public StatusDoProduto StatusDoProduto { get; private set; }

        public virtual Marca Marca {get; private set; }

        public virtual Material Material {get; private set; }

        public virtual Categoria Categoria {get; private set; }

        public virtual Sessao Sessao {get; private set; }

        public ValidationResult ResultadoValidacao { get; set; }

        public bool IsValid(IProdutoRepository repository)
        {
            ResultadoValidacao = new ProdutoAptoParaCadastroValidation(repository).Validate(this);
            return ResultadoValidacao.IsValid;
        }

        private void ValidarCodigo(string codigo)
        {
            if (this.ValidarCodigoEhValido(codigo))
                this.Codigo = codigo;
        }

        private void ValidarComprimentoHaste(int comprimento)
        {
            if (this.ValidarComprimentoHasteEhValido(comprimento))
                this.ComprimentoHaste = comprimento;
        }

        private void ValidarCurvatura(int curvatura)
        {
            if (this.ValidarCurvaturaEhValido(curvatura))
                this.Curvatura = curvatura;
        }

        private void ValidarTamanhoAro(int tamanho)
        {
            if (this.ValidarTamanhoAroEhValido(tamanho))
                this.TamanhoAro = tamanho;
        }

        private void ValidarTamanhoPonte(int tamanho)
        {
            if (this.ValidarTamanhoPonteEhValido(tamanho))
                this.TamanhoPonte = tamanho;
        }

        private void ValidarCor(string cor)
        {
            if (this.ValidarCorEhValido(cor))
                this.Cor = cor;
        }

        private void ValidarDescricao(string descricao)
        {
            if (this.ValidarDescricaoEhValido(descricao))
                this.Descricao = descricao;
        }

        private void ValidarModelo(string modelo)
        {
            if (this.ValidarModeloEhValido(modelo))
                this.Modelo = modelo;
        }

        private void ValidarMaterial(Guid material)
        {
            if (this.ValidarMaterialEhValido(material))
                this.MaterialId = material;
        }

        private void ValidarMarca(Guid marca)
        {
            if (this.ValidarMarcaEhValido(marca))
                this.MarcaId = marca; 
        }

        private void ValidarCategoria(Guid categoriaId)
        {
            if (this.ValidarCategoriaEhValido(categoriaId))
                this.CategoriaId = categoriaId;
        }

        private void ValidarSessao(Guid sessaoId)
        {
            if (this.ValidarSessaoEhValido(sessaoId))
                this.SessaoId = sessaoId;
        }

        public void MovimentarProduto(StatusDoProduto status)
        {
            this.DataMovimentacao = DateTime.Now;
            this.StatusDoProduto = status;
            if (status == StatusDoProduto.Vendidos) this.EmEstoque = false;
        }

        public class Factory
        {
            public static Produto NovoProduto(string descricao, string modelo, string codigo, string cor, int tamanhoAro, int tamanhoPonte, int comprimentoHaste, int curvatura, int alturaLente)
            {
                return new Produto()
                {
                    MarcaId = Guid.NewGuid(),
                    MaterialId = Guid.NewGuid(),
                    CategoriaId = Guid.NewGuid(),
                    EmEstoque = true,
                    DataEntrada = DateTime.Now,
                    ValorCompra = 0,
                    ValorVenda = 0,
                    Descricao = descricao,
                    Modelo = modelo,
                    Codigo = codigo,
                    Cor = cor,
                    TamanhoAro = tamanhoAro,
                    TamanhoPonte = tamanhoPonte,
                    ComprimentoHaste = comprimentoHaste,
                    Curvatura = curvatura,
                    AlturaLente = alturaLente
                };
            }
        }
    }
}