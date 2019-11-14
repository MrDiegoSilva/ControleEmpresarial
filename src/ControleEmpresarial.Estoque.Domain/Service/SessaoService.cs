using System;
using System.Collections.Generic;
using ControleEmpresarial.Estoque.Domain.Entities;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Interface.Service;
using ControleEmpresarial.Estoque.Domain.Validation.Sessao;

namespace ControleEmpresarial.Estoque.Domain.Service
{
    public class SessaoService : ServiceBase<Sessao>, ISessaoService
    {
        private readonly ISessaoRepository _sessaoRepository;

        public SessaoService(ISessaoRepository repository) : base(repository)
        {
            _sessaoRepository = repository;
        }

        public Sessao Adicionar(Sessao sessao)
        {
            sessao.ResultadoValidacao = new SessaoAptaParaCadastroValidation(_sessaoRepository).Validate(sessao);
            if (PossuiConformidade(sessao.ResultadoValidacao))
                _sessaoRepository.Add(sessao);
            return sessao;
        }

        public Sessao RetornarPorDescricao(string descricao)
        {
            return _sessaoRepository.RetornarPorDescricao(descricao);
        }

        public IList<Sessao> RetornarListaPorDescricao(string descricao)
        {
            return _sessaoRepository.RetornarListaPorDescricao(descricao);
        }

        public IList<Sessao> ObterPorLocalidade(Guid localidadeId)
        {
            return _sessaoRepository.ObterPorLocalidade(localidadeId);
        }
    }
}