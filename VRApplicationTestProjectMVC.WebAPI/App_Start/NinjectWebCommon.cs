using System;
using System.Web;
using System.Web.Http;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using Ninject.Web.WebApi;
using VRApplicantTestProject_Services;
using VRApplicantTestProject_Services.Interfaces;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(VRApplicationTestProjectMVC.WebAPI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(VRApplicationTestProjectMVC.WebAPI.App_Start.NinjectWebCommon), "Stop")]

namespace VRApplicationTestProjectMVC.WebAPI.App_Start
{
    public static class NinjectWebCommon
    {
        #region Methods
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        private static IKernel _kernel;

        public static IKernel Kernel
        {
            get
            {
                return _kernel;
            }
        }

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
            _kernel = new StandardKernel();
            try
            {
                _kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                _kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(_kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(_kernel);
                return _kernel;
            }
            catch
            {
                _kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IAccountingService>().To<AccountingService >().InRequestScope();
        }
        #endregion
    }
}