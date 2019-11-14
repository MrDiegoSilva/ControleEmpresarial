using System.Reflection;
using System.Web.Mvc;
using ControleEmpresarial.Core.Domain.Events;
using ControleEmpresarial.Estoque.Infra.IoC;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

[assembly: WebActivator.PostApplicationStartMethod(typeof(ControleEmpresarial.UI.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace ControleEmpresarial.UI.App_Start
{

    
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            // Necess�rio para registrar o ambiente do Owin que � depend�ncia do Identity
            // Feito fora da camada de IoC para n�o levar o System.Web para fora
            //container.RegisterPerWebRequest(() =>
            //{
            //    if (HttpContext.Current != null && HttpContext.Current.Items["owin.Environment"] == null && container.IsVerifying())
            //    {
            //        return new OwinContext().Authentication;
            //    }
            //    return HttpContext.Current.GetOwinContext().Authentication;

            //});

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            // N�o utilizar o Verify devido a solicita��o dinamica de depend�ncias.
            //container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            DomainEvent.Container = new DomainEventsContainer(DependencyResolver.Current);
        }

        private static void InitializeContainer(Container container)
        {
            Bootstrapper.Register(container);
        }
    }
}