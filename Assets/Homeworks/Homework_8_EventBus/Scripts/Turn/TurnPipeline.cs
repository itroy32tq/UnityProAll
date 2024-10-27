namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class TurnPipeline : Pipeline
    {
        private readonly IServiceFactory _serviceFactory;

        public TurnPipeline(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        public void AddTaskOfType<T>() where T : Task
        { 
            var task = _serviceFactory.Create<T>();
            AddTask(task);
        }
    }
}