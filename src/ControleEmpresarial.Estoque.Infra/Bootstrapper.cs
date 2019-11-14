using AutoMapper;
using ControleEmpresarial.Core.Domain.Events;
using ControleEmpresarial.Core.Domain.Handlers;
using ControleEmpresarial.Core.Domain.Interfaces;
using ControleEmpresarial.Estoque.Application.AppService;
using ControleEmpresarial.Estoque.Application.AutoMapper;
using ControleEmpresarial.Estoque.Application.Interface;
using ControleEmpresarial.Estoque.Data.Context;
using ControleEmpresarial.Estoque.Data.Interfaces;
using ControleEmpresarial.Estoque.Data.Repository;
using ControleEmpresarial.Estoque.Data.UoW;
using ControleEmpresarial.Estoque.Domain.Interface.Repository;
using ControleEmpresarial.Estoque.Domain.Interface.Service;
using ControleEmpresarial.Estoque.Domain.Service;
using SimpleInjector;

namespace ControleEmpresarial.Estoque.Infra.IoC
{
    public class Bootstrapper
    {
        public static Container MyContainer { get; set; }

        public static void Register(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe;
            // Lifestyle.Scoped => Uma instancia unica para o request;

            MyContainer = container;

            var config = AutoMapperConfig.RegisterMappings();

            container.RegisterSingleton(config);
            container.Register(() => container.GetInstance<MapperConfiguration>().CreateMapper(), Lifestyle.Scoped);

            // APP
            container.Register<IMarcaAppService, MarcaAppService>(Lifestyle.Scoped);
            container.Register<ICategoriaAppService, CategoriaAppService>(Lifestyle.Scoped);
            container.Register<IMaterialAppService, MaterialAppService>(Lifestyle.Scoped);
            container.Register<IProdutoAppService, ProdutoAppService>(Lifestyle.Scoped);
            container.Register<IAlertaAppService, AlertaAppService>(Lifestyle.Scoped);
            container.Register<ILocalidadeAppService, LocalidadeAppService>(Lifestyle.Scoped);
            container.Register<ISessaoAppService, SessaoAppService>(Lifestyle.Scoped);

            // Domain
            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>), Lifestyle.Scoped);
            container.Register<IMarcaService, MarcaService>(Lifestyle.Scoped);
            container.Register<ICategoriaService, CategoriaService>(Lifestyle.Scoped);
            container.Register<IMaterialService, MaterialService>(Lifestyle.Scoped);
            container.Register<IProdutoService, ProdutoService>(Lifestyle.Scoped);
            container.Register<IAlertaService, AlertaService>(Lifestyle.Scoped);
            container.Register<ILocalidadeService, LocalidadeService>(Lifestyle.Scoped);
            container.Register<ISessaoService, SessaoService>(Lifestyle.Scoped);

            //Infra Dados
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<EstoqueContext>(Lifestyle.Scoped);

            // Infra Dados Repos
            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>), Lifestyle.Scoped);
            container.Register<ICategoriaRepository, CategoriaRepository>(Lifestyle.Scoped);
            container.Register<IMarcaRepository, MarcaRepository>(Lifestyle.Scoped);
            container.Register<IMaterialRepository, MaterialRepository>(Lifestyle.Scoped);
            container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Scoped);
            container.Register<IAlertaRepository, AlertaRepository>(Lifestyle.Scoped);
            container.Register<ILocalidadeRepository, LocalidadeRepository>(Lifestyle.Scoped);
            container.Register<ISessaoRepository, SessaoRepository>(Lifestyle.Scoped);

            // Handlers
            container.Register<IHandler<DomainNotification>, DomainNotificationHandler>(Lifestyle.Scoped);

        }
    }
}