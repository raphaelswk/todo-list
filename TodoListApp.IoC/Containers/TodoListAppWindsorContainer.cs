using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace TodoListApp.IoC.Containers
{
    public static class TodoListAppWindsorContainer
    {
        private static WindsorContainer _container;
        private readonly static object syncRoot = new object();

        private static IWindsorContainer GetContainer()
        {
            if (_container == null)
            {
                lock (syncRoot)
                {
                    if (_container == null)
                    {
                        _container = new WindsorContainer();

                        _container.Register(Component.For<IKernel>().Instance(_container.Kernel), 
                                            Component.For<IWindsorContainer>().Instance(_container));

                        _container.Install(FromAssembly.InThisApplication());
                    }
                }
            }

            return _container;
        }

        public static T Resolve<T>()
        {
            return GetContainer().Resolve<T>();
        }
    }
}
