using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using System.IO;
using Unity;
using Unity.Lifetime;
using Unity.Microsoft.Logging;
using Woodworking_shop.Entities;
using Woodworking_shop.Forms;
using Woodworking_shop.Reports;
using Woodworking_shop.Reports.Builders;
using Woodworking_shop.Repositories;
using Woodworking_shop.Repositories.Implementations;

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
            container.RegisterType<WordReport>();
            container.RegisterType<ExcelReport>();
            container.RegisterType<ChartReport>();

            container.RegisterType<FormDirectoryReport>();
            container.RegisterType<FormProductReport>();
            container.RegisterType<FormProductChartReport>();
            return container;
        }
    }
}