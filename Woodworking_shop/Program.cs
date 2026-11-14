using Unity;
using Unity.Lifetime;
using Unity.Microsoft.Logging;
using Microsoft.Extensions.Logging;
using Serilog;
using Woodworking_shop.Repositories;
using Woodworking_shop.Repositories.Implementations;
using Woodworking_shop.Forms;
using Woodworking_shop.Entities;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Woodworking_shop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); 
            ApplicationConfiguration.Initialize();
            Application.Run(CreateContainer().Resolve<FormMain>());
        }


        private static IUnityContainer CreateContainer()
        {
            var container = new UnityContainer();

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddSerilog(new LoggerConfiguration()
                .ReadFrom.Configuration(new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build())
                .CreateLogger());

            container.AddExtension(new LoggingExtension(loggerFactory));

            container.RegisterType<DataContext>(new TransientLifetimeManager());

            container.RegisterType<IProductRepository, ProductRepository>(new TransientLifetimeManager());
            container.RegisterType<IMaterialRepository, MaterialRepository>(new TransientLifetimeManager());
            container.RegisterType<IOrderRepository, OrderRepository>(new TransientLifetimeManager());
            container.RegisterType<IMaterialReservationRepository, MaterialReservationRepository>(new TransientLifetimeManager());
            container.RegisterType<IConsumptionRateRepository, ConsumptionRateRepository>(new TransientLifetimeManager());
            container.RegisterType<IOrderItemRepository, OrderItemRepository>(new TransientLifetimeManager());

            return container;
        }
    }
}