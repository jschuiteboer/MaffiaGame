using Castle.Windsor;
using Castle.Windsor.Installer;
using MafiaGame.Windsor;
using System.Web.Mvc;

namespace MafiaGame
{
    public static class WindsorContainerHandler
    {
        private static IWindsorContainer _container;

        public static IWindsorContainer Container
        {
            get
            {
                if(_container == null)
                {
                    _container = new WindsorContainer().Install(FromAssembly.This());
                }

                return _container;
            }
        }


        public static void Setup()
        {
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(Container.Kernel));
        }

        public static void Dispose()
        {
            _container.Dispose();
        }
    }
}