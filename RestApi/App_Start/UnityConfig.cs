using Microsoft.Practices.Unity;
using RestApi.Models;
using System;
using System.Web.Http;
using Unity.WebApi;

namespace RestApi
{
    public static class UnityConfig
    {

        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterComponents(container);
            return container;
        });

        // Call this to initialise the Unity Container
        public static IUnityContainer GetUnityContainer()
        {
            return Container.Value;
        }

        public static void RegisterComponents(IUnityContainer container)
        {
            container.RegisterType<IPatientContext, PatientContext>();
            container.RegisterType<IPatientContext, PatientInMemoryContext>("test_context");

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}