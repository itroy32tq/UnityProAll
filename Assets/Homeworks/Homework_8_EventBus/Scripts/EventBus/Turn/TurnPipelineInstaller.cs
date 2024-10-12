using System;
using Zenject;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class TurnPipelineInstaller : IInitializable, IDisposable
    {
        private readonly TurnPipeline _turnPipeline;
        private readonly IServiceFactory _serviceFactory;
        
        public TurnPipelineInstaller(TurnPipeline turnPipeline, IServiceFactory serviceFactory)
        {
            _turnPipeline = turnPipeline;
            _serviceFactory = serviceFactory;
        }

        void IInitializable.Initialize()
        {
            _turnPipeline.AddTask(new StartTurnTask());
            _turnPipeline.AddTask(_serviceFactory.Create<PlayerTurnTask>());
            _turnPipeline.AddTask(_serviceFactory.Create<StartVisualPipelineTask>());
            _turnPipeline.AddTask(new FinishTurnTask());
        }

        void IDisposable.Dispose()
        {
            _turnPipeline.ClearTasks();
        }
    }
}