using System.Reflection;
using Owin;
using System.Web.Http;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using VRApplicantTestProject_Services;
using VRApplicantTestProject_Services.Interfaces;
using VRApplicantTestProjectOWIN.WebAPI.Ninject;

namespace OwinSelfhostSample
{
    public class Startup
    {

        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseNinjectMiddleware(LocalNinject.CreateKernel).UseNinjectWebApi(config);
        }
    }
}