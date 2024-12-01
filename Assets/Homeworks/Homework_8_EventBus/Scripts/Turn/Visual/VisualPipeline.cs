namespace Assets.Homeworks.Homework_8_EventBus
{
    public sealed class VisualPipeline : Pipeline
    {
        private readonly IServiceFactory _serviceFactory;
        public bool HasTasks => Tasks.Count > 0;
    }
}