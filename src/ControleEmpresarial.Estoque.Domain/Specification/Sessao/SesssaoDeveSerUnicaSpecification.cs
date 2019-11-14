using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using DomainValidation.Interfaces.Specification;

namespace ControleEmpresarial.Estoque.Domain.Specification.Sessao
{
    public class SesssaoDeveSerUnicaSpecification : ISpecification<Entities.Sessao>
    {
        private readonly ISessaoRepository _repository;

        public SesssaoDeveSerUnicaSpecification(ISessaoRepository repository)
        {
            _repository = repository;
        }

        public bool IsSatisfiedBy(Entities.Sessao sessao)
        {
            return _repository.ObterSessaoDaLocalidade(sessao.Id, sessao.LocalidadeId) == null;
        }
    }
}