using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using DomainValidation.Interfaces.Specification;

namespace ControleEmpresarial.Estoque.Domain.Specification.Alerta
{
    public class AlertaDeveSerUnicoSpecification : ISpecification<Entities.Alerta>
    {
        private readonly IAlertaRepository _repository;
        public AlertaDeveSerUnicoSpecification(IAlertaRepository repository)
        {
            _repository = repository;
        }

        public bool IsSatisfiedBy(Entities.Alerta alerta)
        {
            return _repository.RetornarPorDescricao(alerta.Descricao) == null;
        }
    }
}