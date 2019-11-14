using System.Collections.Generic;
using ControleEmpresarial.Core.Domain.Events;
using ControleEmpresarial.Core.Domain.Interfaces;

namespace ControleEmpresarial.Core.Domain.Handlers
{
    public class DomainNotificationHandler : IHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public void Handle(DomainNotification args)
        {
            _notifications.Add(args);
        }

        public IEnumerable<DomainNotification> Notify()
        {
            return GetValues();
        }

        public List<DomainNotification> GetValues()
        {
            return _notifications;
        }

        public bool HasNotifications()
        {
            return GetValues().Count > 0;
        }

        public void Dispose()
        {
            this._notifications = new List<DomainNotification>();
        }
    }
}