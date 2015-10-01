using System.Web.Http;
using API;
using API.Models;
using API.Models.DbContexts;
using API.Repositories;
using API.Services;
using AutoMapper;
using BerthaSounds.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Ninject.Activation;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BerthaSounds.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(BerthaSounds.App_Start.NinjectWebCommon), "Stop")]

namespace BerthaSounds.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;
    using Ninject.Activation.Strategies;

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
            var kernel = new StandardKernel();
            try
            {
                kernel.Components.Add<IActivationStrategy, CustomActivationStrategy>();
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectWebApiDependencyResolver(kernel);
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
            kernel.Bind(x => x.FromAssemblyContaining<IUnitOfWork>()
                .SelectAllClasses()
                .EndingWith("Repository")
                .BindDefaultInterfaces());

            kernel.Bind(x => x.FromAssemblyContaining<IUnitOfWork>()
                .SelectAllClasses()
                .EndingWith("Service")
                .BindDefaultInterface());
            kernel.Load(new CustomServiceRegistrationModule());

			kernel.Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>()
				.InRequestScope().WithConstructorArgument("context", kernel.Get<BerthaContext>());
			kernel.Bind<UserManager<ApplicationUser>>().ToSelf();
			kernel.Bind<IRoleStore<IdentityRole, string>>().To<RoleStore<IdentityRole, string, IdentityUserRole>>();
			kernel.Bind<RoleManager<IdentityRole>>().ToSelf();


			// Old Ninject:
			
            //kernel.Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>()
            //    .WithConstructorArgument("context", context => kernel.Get<ApplicationDbContext>());
            //kernel.Bind<ApplicationUserManager>().ToSelf().InRequestScope();
            //kernel.Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>()
            //            .InRequestScope()
            //            .WithConstructorArgument("context", kernel.Get<ApplicationDbContext>());
            //kernel.Bind<UserManager<ApplicationUser>>().ToSelf()
            //            .InRequestScope();
            kernel.Bind<IAuthenticationManager>()
                .ToMethod(context => HttpContext.Current.GetOwinContext().Authentication);

            kernel.Rebind<IMappingEngine>().ToMethod(context => Mapper.Engine);
        }        
    }
}
