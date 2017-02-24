using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Autofac;
using DBase.Domain.Services;
using DBase.Domain.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace TestWithForm
{
    static class Program
    {
        private static IContainer Container { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<StockService>().As<IStoreService>().WithParameter(new TypedParameter(typeof(string), "TestWithForm.Properties.Settings.Setting"));
            Container = builder.Build();
            var serviceClass = Container.Resolve<IStoreService>();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(serviceClass));
        }
    }
}
