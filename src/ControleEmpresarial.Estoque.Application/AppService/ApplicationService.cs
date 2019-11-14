using ControleEmpresarial.Core.Domain.Events;
using ControleEmpresarial.Core.Domain.Interfaces;
using ControleEmpresarial.Estoque.Data.Interfaces;

namespace ControleEmpresarial.Estoque.Application.AppService
{
    public class ApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IHandler<DomainNotification> Notifications;

        public ApplicationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this.Notifications = DomainEvent.Container.GetInstance<IHandler<DomainNotification>>();
        }

        public bool Commit()
        {
            if (Notifications.HasNotifications())
                return false;

            _unitOfWork.Commit();
            return true;
        }
    }
}