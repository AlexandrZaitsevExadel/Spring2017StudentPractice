using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using DBase.Domain.Services;

namespace WebAPI.Utils
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            
            //builder.RegisterType<StockService>().As<IStoreService>().WithParameter(new TypedParameter(typeof(string), "TestWithForm.Properties.Settings.Setting"));
            builder.RegisterControllers(typeof(WebApiApplication).Assembly).InstancePerRequest();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}