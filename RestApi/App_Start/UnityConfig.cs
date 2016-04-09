using Microsoft.Practices.Unity;
using RestApi.Models;
using System.Web.Http;
using Unity.WebApi;

namespace RestApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IPatientContext, PatientContext>();
//            container.RegisterType<IPatientContext, PatientInMemoryContext>("test_context");

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}