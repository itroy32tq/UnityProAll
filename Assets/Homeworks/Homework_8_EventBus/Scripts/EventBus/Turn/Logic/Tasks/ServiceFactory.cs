using Zenject;

namespace Assets.Homeworks.Homework_8_EventBus
{
    public class ServiceFactory : IServiceFactory
    {
        private readonly DiContainer _container;

        public ServiceFactory(DiContainer container)
        {
            _container = container;
        }

        public T Create<T>() where T : class
        {
            return _container.Resolve<T>();
        }
    }
}
