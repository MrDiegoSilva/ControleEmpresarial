using System;

namespace ControleEmpresarial.Core.Domain.Interfaces
{
    public interface IAggregate
    {
        Guid Id { get; }
    }
}