using System;

namespace ControleEmpresarial.Core.Domain.Interfaces
{
    public interface IDomainEvent
    {
        int Versao { get; }
        DateTime DataOcorrencia { get; }
    }
}