using System;
using System.Windows.Forms;
using Autofac;
using DBase.Domain.Services;

namespace TestWithForm
{
    internal static class Program
    {
        private static IContainer Container { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
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
