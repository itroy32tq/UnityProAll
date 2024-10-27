namespace Assets.Homeworks.Homework_8_EventBus
{
    internal interface IServiceFactory
    {
        T Create<T>() where T : class;
    }
}
