using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleEmpresarial.Estoque.Domain.Entities;
using ControleEmpresarial.Estoque.Domain.Entities.Enum;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Interface.Service;
using ControleEmpresarial.Estoque.Domain.Validation.Alerta;
using DomainValidation.Validation;

namespace ControleEmpresarial.Estoque.Domain.Service
{
    public class AlertaService : ServiceBase<Alerta>, IAlertaService
    {
        private readonly IAlertaRepository _repository;
        private readonly IProdutoRepository _produtoRepository;

        public AlertaService(IAlertaRepository repository, IProdutoRepository produtoRepository) : base(repository)
        {
            _repository = repository;
            _produtoRepository = produtoRepository;
        }

        public IList<Alerta> BuscarAlerta(string descricao, CondicoesDeAlerta condicaoDeAlerta, StatusAlerta statusAlerta)
        {
            return _repository.BuscarAlerta(descricao, condicaoDeAlerta, statusAlerta);
        }

        public Alerta Adicionar(Alerta alerta)
        {
            alerta.ResultadoValidacao = new AlertaAptoParaCadastroValidation(_repository).Validate(alerta);
            if (PossuiConformidade(alerta.ResultadoValidacao))
                _repository.Add(alerta);
            return alerta;
        }

        public Alerta RetornarPorDescricao(string descricao)
        {
            return _repository.RetornarPorDescricao(descricao);
        }

        public async Task<int> VerificarAlertas()
        {
            int disparos = 0;
            var alertas = _repository.GetAll(true).ToList();
            foreach (var itemAlerta in alertas)
            {
                disparos += await VerificarAlertas(itemAlerta);
                _repository.Update(itemAlerta);
            }

            return disparos;
        }

        public Task<int> VerificarAlertas(Alerta alerta)
        {
            int disparos = 0;
            var resultadoValidacao = ValidarAlerta(alerta);
            if (resultadoValidacao != null && !resultadoValidacao.IsValid)
            {
                alerta.AtivarAlerta();
                disparos++;
            }
            else
            {
                alerta.DesativarAlerta();
            }
            return Task.FromResult(disparos);
        }

        public Task<int> VerificarAlertasDisparados()
        {
            return _repository.VerificarAlertasDisparados();
        }

        private ValidationResult ValidarAlerta(Alerta alerta)
        {
            switch (alerta.CondicaoDeAlerta)
            {
                case CondicoesDeAlerta.Definir_Limite_Para_Todo_Estoque:
                    return new AlertaAplicadoParaTodosOsProdutosValidation(_produtoRepository).Validate(alerta);

                case CondicoesDeAlerta.Definir_Limite_Para_Armazenamento:
                    return new AlertaAplicadoParaArmazenamentoValidation(_produtoRepository).Validate(alerta);

                case CondicoesDeAlerta.Definir_Limite_Para_Valor_Máximo:
                    return new AlertaAplicadoParaValorMaximoValidation(_produtoRepository).Validate(alerta);

                case CondicoesDeAlerta.Definir_Limite_Para_Valor_Mínimo:
                    return new AlertaAplicadoParaValorMinimoValidation(_produtoRepository).Validate(alerta);

                case CondicoesDeAlerta.Definir_Limite_Por_Especificação_Técnica:
                    return new AlertaAplicadoParaTamanhoValidation(_produtoRepository).Validate(alerta);

                case CondicoesDeAlerta.Definir_Limite_Por_Localidade:
                    return new AlertaAplicadoParaLocalidadeValidation(_produtoRepository).Validate(alerta);

                case CondicoesDeAlerta.Definir_Limite_Por_Marca:
                    return new AlertaAplicadoParaMarcaValidation(_produtoRepository).Validate(alerta);

                case CondicoesDeAlerta.Definir_Limite_Por_Modelo:
                    return new AlertaAplicadoParaModeloValidation(_produtoRepository).Validate(alerta);
                case CondicoesDeAlerta.Definir_Limite_Para_Tempo_Em_Estoque:
                    return new AlertaAplicadoPorTempoEmEstoqueValidation(_produtoRepository).Validate(alerta);
                default:
                    return null;
            }
        }
    }
}