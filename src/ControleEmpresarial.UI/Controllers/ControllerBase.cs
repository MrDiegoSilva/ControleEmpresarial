using System.Linq;
using System.Web.Mvc;
using ControleEmpresarial.Core.Domain.Events;
using ControleEmpresarial.Core.Domain.Interfaces;

namespace ControleEmpresarial.UI.Controllers
{
    public class ControllerBase : Controller
    {
        // GET: Base
        public IHandler<DomainNotification> Notifications;

        public ControllerBase()
        {
            this.Notifications = DomainEvent.Container.GetInstance<IHandler<DomainNotification>>();
        }

        public bool ValidarErrosDominio()
        {
            if (!Notifications.HasNotifications()) return false;
            var listaErros = Notifications.GetValues().Select(error => error.Value).ToList();
            TempData["AlertMessage"] = listaErros;
            return true;
        }
    }
}