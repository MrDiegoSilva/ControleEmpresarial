using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Specification.Sessao;
using DomainValidation.Interfaces.Validation;
using DomainValidation.Validation;

namespace ControleEmpresarial.Estoque.Domain.Validation.Sessao
{
    public class SessaoAptaParaCadastroValidation : Validator<Entities.Sessao>
    {
        public SessaoAptaParaCadastroValidation(ISessaoRepository repository)
        {
            var sessaoDuplicada = new SesssaoDeveSerUnicaSpecification(repository);

            base.Add("sessaoDuplicada", new Rule<Entities.Sessao>(sessaoDuplicada, "Sessão já cadastrada!"));
        }
    }
}