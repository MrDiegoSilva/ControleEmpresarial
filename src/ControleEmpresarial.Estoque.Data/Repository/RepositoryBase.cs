using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ControleEmpresarial.Estoque.Data.Context;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;

namespace ControleEmpresarial.Estoque.Data.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly EstoqueContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(EstoqueContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            _dbSet.Add(obj);
        }

        public void Update(TEntity obj)
        {
            var entry = _context.Entry(obj);
            _dbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public void Delete(TEntity obj)
        {
            var entry = _context.Entry(obj);
            _dbSet.Attach(obj);
            entry.State = EntityState.Deleted;
        }

        public TEntity GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll(bool @readonly = false)
        {
            return @readonly
                ? _dbSet.AsNoTracking().ToList()
                : _dbSet.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
        {
            return @readonly
                ? _dbSet.Where(predicate).AsNoTracking()
                : _dbSet.Where(predicate);
        }
    }
}