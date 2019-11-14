using System;
using ControleEmpresarial.Core.Domain.Interfaces;

namespace ControleEmpresarial.Core.Domain.ValuesObjects
{
    public class Aggregate : IAggregate
    {
        public Aggregate()
        {
            this.Id = Guid.NewGuid();
        }

        public Aggregate(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; protected set; }
    }
}