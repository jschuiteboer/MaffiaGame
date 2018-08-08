using Castle.Windsor;
using Castle.Windsor.Installer;
using MafiaGame.Windsor;
using System.Web.Mvc;

namespace MafiaGame
{
    public static class WindsorContainerHandler
    {
        private static IWindsorContainer container;

        public static void Setup()
        {
            container = new WindsorContainer()
                .Install(FromAssembly.This());
            
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container.Kernel));
        }

        public static void Dispose()
        {
            container.Dispose();
        }
    }
}