using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ControleEmpresarial.Estoque.Domain.Interface.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        void Update(TEntity obj);

        void Delete(TEntity obj);

        TEntity GetById(Guid id);

        IEnumerable<TEntity> GetAll(bool @readonly = false);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);
    }
}