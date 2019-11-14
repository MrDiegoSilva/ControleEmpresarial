using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using DomainValidation.Interfaces.Specification;

namespace ControleEmpresarial.Estoque.Domain.Specification.Alerta
{
    public class AlertaAplicadoParaTodosOsProdutosSpecification : ISpecification<Entities.Alerta>
    {
        private readonly IProdutoRepository _produtoRepository;

        public AlertaAplicadoParaTodosOsProdutosSpecification(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public bool IsSatisfiedBy(Entities.Alerta alerta)
        {
            var disparo = _produtoRepository.TotalDeProdutos();
            return disparo > alerta.Quantidade;
        }
    }
}