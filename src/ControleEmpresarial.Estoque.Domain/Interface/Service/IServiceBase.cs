using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ControleEmpresarial.Estoque.Domain.Interface.Service
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        TEntity GetById(Guid id, bool @readonly = false);
        IEnumerable<TEntity> GetAll(bool @readonly = false);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);
        void Add(TEntity department);
        void Update(TEntity department);
        void Delete(TEntity entity);
    }
}