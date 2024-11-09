
using UnityEngine;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class TurnPipeline : Pipeline
    {
        private readonly IServiceFactory _serviceFactory;
        private readonly VisualPipeline _visualPipeline;

        public TurnPipeline(IServiceFactory serviceFactory, VisualPipeline visualPipeline)
        {
            _serviceFactory = serviceFactory;
            _visualPipeline = visualPipeline;
        }

        public void AddTaskOfType<T>() where T : Task
        { 
            var task = _serviceFactory.Create<T>();
            AddTask(task);
        }

        protected override void OnTaskFinished()
        {
            _visualPipeline.OnFinished += ContinueAfterVisuals;

            if (_visualPipeline.HasTasks)
            {
                _visualPipeline.Run();
            }
            else
            {
                ContinueAfterVisuals();
            }
        }

        private void ContinueAfterVisuals()
        {
            _visualPipeline.OnFinished -= ContinueAfterVisuals;

            _visualPipeline.ClearTasks();

            base.OnTaskFinished();
        }
    }
}