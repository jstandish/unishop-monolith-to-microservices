using Microsoft.Practices.Unity;
using System.Web.Http;
using MonoToMicroLegacy.Core.Data.Implementation;
using MonoToMicroLegacy.Core.Data.Interfaces;
using MonoToMicroLegacy.Core.Repository.Implementation;
using MonoToMicroLegacy.Core.Repository.Interfaces;
using MonoToMicroLegacy.Core.Services.Implementation;
using MonoToMicroLegacy.Core.Services.Interfaces;
using Unity.WebApi;
using HealthRepository = MonoToMicroLegacy.Core.Repository.Implementation.HealthRepository;

namespace MonoToMicroLegacy
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            MapServices(container);
            MapRepository(container);
            MapData(container);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        private static void MapServices(UnityContainer container)
        {
            container.RegisterType<IHealthService, HealthService>();
            container.RegisterType<IUnicornService, UnicornService>();
            container.RegisterType<IUserService, UserService>();
        }

        private static void MapRepository(UnityContainer container)
        {
            container.RegisterType<IHealthRepository, HealthRepository>();
            container.RegisterType<IUnicornRepository, UnicornRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
        }

        private static void MapData(UnityContainer container)
        {
            container.RegisterType<IHealthData, HealthData>();
            container.RegisterType<IUnicornData, UnicornData>();
            container.RegisterType<IUserData, UserData>();
        }
    }
}