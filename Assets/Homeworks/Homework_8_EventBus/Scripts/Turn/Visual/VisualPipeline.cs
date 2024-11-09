namespace Assets.Homeworks.Homework_8_EventBus
{
    public sealed class VisualPipeline : Pipeline
    {
        public bool HasTasks => Tasks.Count > 0;
    }
}