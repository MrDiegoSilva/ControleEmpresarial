using System.Collections.Generic;
using ControleEmpresarial.Estoque.Domain.Entities;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Interface.Service;
using ControleEmpresarial.Estoque.Domain.Validation.Marca;

namespace ControleEmpresarial.Estoque.Domain.Service
{
    public class MarcaService : ServiceBase<Marca> , IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository) : base(marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public Marca Adicionar(Marca marca)
        {
            marca.ResultadoValidacao = new MarcaAptaParaCadastroValidation(_marcaRepository).Validate(marca);
            if(PossuiConformidade(marca.ResultadoValidacao))
                _marcaRepository.Add(marca);
            return marca;
        }

        public Marca RetornarPorDescricao(string descricao)
        {
            return _marcaRepository.RetornarPorDescricao(descricao);
        }

        public IList<Marca> RetornarListaPorDescricao(string descricao)
        {
            return _marcaRepository.RetornarListaPorDescricao(descricao);
        }
    }
}