using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Ninject;
using Ninject.Web.WebApi.OwinHost;
using VRApplicantTestProject_Services;
using VRApplicantTestProject_Services.Interfaces;

namespace VRApplicantTestProjectOWIN.WebAPI.Ninject
{
    public static class LocalNinject
    {
        public static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterServices(kernel);
            GlobalConfiguration.Configuration.DependencyResolver = new OwinNinjectDependencyResolver(kernel);
            return kernel;
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IAccountingService>().To<AccountingService>().InSingletonScope();
        }
    }
}
