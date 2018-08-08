using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace MafiaGame.Windsor
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly()
                    .InNamespace("MafiaGame.Services.impl")
                    .WithServiceFirstInterface()
                    .LifestylePerWebRequest()
            );
        }
    }
}