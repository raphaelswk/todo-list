using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using TodoListApp.Persistence.Implementations;

namespace TodoListApp.IoC.Installers
{
    public class PersistenceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssembly(typeof(UserDAO).Assembly)
                                      .Pick()
                                      .WithServiceAllInterfaces()
                                      .LifestyleTransient());

            container.Register(Classes.FromAssembly(typeof(UserTaskDAO).Assembly)
                                      .Pick()
                                      .WithServiceAllInterfaces()
                                      .LifestyleTransient());
        }
    }
}
