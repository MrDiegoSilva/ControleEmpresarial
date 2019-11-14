using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleEmpresarial.Estoque.Data.Context;
using ControleEmpresarial.Estoque.Domain.Entities;
using ControleEmpresarial.Estoque.Domain.Entities.Enum;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;

namespace ControleEmpresarial.Estoque.Data.Repository
{
    public class AlertaRepository : RepositoryBase<Alerta>, IAlertaRepository
    {
        public AlertaRepository(EstoqueContext context) : base(context)
        {
        }

        public Alerta RetornarPorDescricao(string descricao)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(a => a.Descricao.Contains(descricao));
        }

        public Task<int> VerificarAlertasDisparados()
        {
            return Task.FromResult(_dbSet.AsNoTracking().Count(a => a.Disparado));
        }

        public IList<Alerta> BuscarAlerta(string descricao, CondicoesDeAlerta condicaoDeAlerta, StatusAlerta statusAlerta)
        {
            switch (statusAlerta)
            {
                case StatusAlerta.Ativo:
                    return _dbSet.AsNoTracking().Where(a => a.Disparado && a.Descricao.Contains(descricao) && a.CondicaoDeAlerta == condicaoDeAlerta).ToList();
                case StatusAlerta.Inativo:
                    return _dbSet.AsNoTracking().Where(a => !a.Disparado && a.Descricao.Contains(descricao) && a.CondicaoDeAlerta == condicaoDeAlerta).ToList();
                case StatusAlerta.TodosOsAlertas:
                    return _dbSet.AsNoTracking().Where(a => a.Descricao.Contains(descricao) && a.CondicaoDeAlerta == condicaoDeAlerta).ToList();
                default:
                    return null;
            }
        }
    }
}