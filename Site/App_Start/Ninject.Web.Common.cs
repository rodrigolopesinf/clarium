[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Site.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Site.App_Start.NinjectWebCommon), "Stop")]

namespace Site.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Millenium.Application.Interfaces;
    using Millenium.Application.Services;
    using Millenium.Domain.Interfaces.Repositories;
    using Millenium.Domain.Interfaces.Services;
    using Millenium.Domain.Services;
    using Millenium.Infra.Data.Repositories;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel(new NinjectSettings { UseReflectionBasedInjection = true });
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IClienteAppService>().To<ClienteAppService>();
            kernel.Bind<IContatoAppService>().To<ContatoAppService>();
            kernel.Bind<IContatoClienteAppService>().To<ContatoClienteAppService>();
            kernel.Bind<IEnderecoAppService>().To<EnderecoAppService>();
            kernel.Bind<IFaturamentoAppService>().To<FaturamentoAppService>();
            kernel.Bind<IMenuAppService>().To<MenuAppService>();
            kernel.Bind<INivelAppService>().To<NivelAppService>();
            kernel.Bind<ISituacaoClienteAppService>().To<SituacaoClienteAppService>();
            kernel.Bind<ISolicitacaoAppService>().To<SolicitacaoAppService>();
            kernel.Bind<ITipoClienteAppService>().To<TipoClienteAppService>();
            kernel.Bind<ITipoSolicitacaoAppService>().To<TipoSolicitacaoAppService>();
            kernel.Bind<IUsuarioAppService>().To<UsuarioAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IClienteService>().To<ClienteService>();
            kernel.Bind<IContatoService>().To<ContatoService>();
            kernel.Bind<IContatoClienteService>().To<ContatoClienteService>();
            kernel.Bind<IEnderecoService>().To<EnderecoService>();
            kernel.Bind<IFaturamentoService>().To<FaturamentoService>();
            kernel.Bind<IMenuService>().To<MenuService>();
            kernel.Bind<INivelService>().To<NivelService>();
            kernel.Bind<ISituacaoClienteService>().To<SituacaoClienteService>();
            kernel.Bind<ISolicitacaoService>().To<SolicitacaoService>();
            kernel.Bind<ITipoClienteService>().To<TipoClienteService>();
            kernel.Bind<ITipoSolicitacaoService>().To<TipoSolicitacaoService>();
            kernel.Bind<IUsuarioService>().To<UsuarioService>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IClienteRepository>().To<ClienteRepository>();
            kernel.Bind<IContatoRepository>().To<ContatoRepository>();
            kernel.Bind<IContatoClienteRepository>().To<ContatoClienteRepository>();
            kernel.Bind<IEnderecoRepository>().To<EnderecoRepository>();
            kernel.Bind<IFaturamentoRepository>().To<FaturamentoRepository>();
            kernel.Bind<IMenuRepository>().To<MenuRepository>();
            kernel.Bind<INivelRepository>().To<NivelRepository>();
            kernel.Bind<ISituacaoClienteRepository>().To<SituacaoClienteRepository>();
            kernel.Bind<ISolicitacaoRepository>().To<SolicitacaoRepository>();
            kernel.Bind<ITipoClienteRepository>().To<TipoClienteRepository>();
            kernel.Bind<ITipoSolicitacaoRepository>().To<TipoSolicitacaoRepository>();
            kernel.Bind<IUsuarioRepository>().To<UsuarioRepository>();
        }        
    }
}