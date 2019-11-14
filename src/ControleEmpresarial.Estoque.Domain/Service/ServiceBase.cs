using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ControleEmpresarial.Core.Domain.Events;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Interface.Service;
using DomainValidation.Validation;

namespace ControleEmpresarial.Estoque.Domain.Service
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            Repository = repository;
        }

        protected IRepositoryBase<TEntity> Repository { get; }


        public virtual TEntity GetById(Guid id, bool @readonly = false)
        {
            return Repository.GetById(id);
        }

        public virtual IEnumerable<TEntity> GetAll(bool @readonly = false)
        {
            return Repository.GetAll(@readonly);
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
        {
            return Repository.Find(predicate, @readonly);
        }


        public virtual void Add(TEntity department)
        {
            Repository.Add(department);

        }

        public virtual void Update(TEntity department)
        {

            Repository.Update(department);
        }

        public virtual void Delete(TEntity entity)
        {
            Repository.Delete(entity);
        }

        protected static bool PossuiConformidade(ValidationResult validationResult)
        {
            if (validationResult == null) return true;
            var notifications = validationResult.Erros.Select(validationError => new DomainNotification(validationError.ToString(), validationError.Message)).ToList();
            if (!notifications.Any()) return true;
            notifications.ToList().ForEach(DomainEvent.Raise);
            return false;
        }
    }
}