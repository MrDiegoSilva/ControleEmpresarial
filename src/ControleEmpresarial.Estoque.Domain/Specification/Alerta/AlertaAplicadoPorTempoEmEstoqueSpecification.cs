using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using DomainValidation.Interfaces.Specification;

namespace ControleEmpresarial.Estoque.Domain.Specification.Alerta
{
    public class AlertaAplicadoPorTempoEmEstoqueSpecification : ISpecification<Entities.Alerta>
    {
        private readonly IProdutoRepository _produtoRepository;

        public AlertaAplicadoPorTempoEmEstoqueSpecification(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public bool IsSatisfiedBy(Entities.Alerta alerta)
        {
            var disparo = _produtoRepository.TotalDeProdutosPorTempoEmEstoque(alerta.ValorCondicao);
            return disparo > alerta.Quantidade;
        }
    }
}