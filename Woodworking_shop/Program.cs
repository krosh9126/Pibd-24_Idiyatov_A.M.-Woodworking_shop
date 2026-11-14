using Unity;
using Unity.Lifetime;
using Woodworking_shop.Forms;
using Woodworking_shop.Repositories;
using Woodworking_shop.Repositories.Implementations;

namespace WoodworkShop
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Application.Run(CreateContainer().Resolve<FormMain>());
        }

        /// <summary>
        /// Метод создания и настройки IoC-контейнера.
        /// </summary>
        private static IUnityContainer CreateContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IProductRepository, ProductRepository>(new TransientLifetimeManager());
            container.RegisterType<IMaterialRepository, MaterialRepository>(new TransientLifetimeManager());
            container.RegisterType<IOrderItemRepository, OrderItemRepository>(new TransientLifetimeManager());
            container.RegisterType<IConsumptionRateRepository, ConsumptionRateRepository>(new TransientLifetimeManager());
            container.RegisterType<IOrderRepository, OrderRepository>(new TransientLifetimeManager());
            container.RegisterType<IMaterialReservationRepository, MaterialReservationRepository>(new TransientLifetimeManager());

            return container;
        }
    }
}