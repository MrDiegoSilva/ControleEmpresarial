using System.Collections.Generic;
using ControleEmpresarial.Estoque.Domain.Entities;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Interface.Service;
using ControleEmpresarial.Estoque.Domain.Validation.Material;

namespace ControleEmpresarial.Estoque.Domain.Service
{
    public class MaterialService : ServiceBase<Material>, IMaterialService
    {
        private readonly IMaterialRepository _repository;

        public MaterialService(IMaterialRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Material Adicionar(Material material)
        {
            material.ResultadoValidacao = new MaterialAptaParaCadastroValidation(_repository).Validate(material);
            if (PossuiConformidade(material.ResultadoValidacao))
                _repository.Add(material);
            return material;
        }

        public Material RetornarPorDescricao(string descricao)
        {
            return _repository.RetornarPorDescricao(descricao);
        }

        public IList<Material> RetornarListaPorDescricao(string descricao)
        {
            return _repository.RetornarListaPorDescricao(descricao);
        }
    }
}