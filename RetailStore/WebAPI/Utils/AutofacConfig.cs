using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;

namespace WebAPI.Utils
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            
            //builder.RegisterType<StockService>().As<IStoreService>().WithParameter(new TypedParameter(typeof(string), "WebAPI.Properties.Settings.ConnectionString"));
            builder.RegisterControllers(typeof(WebApiApplication).Assembly).InstancePerRequest();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}