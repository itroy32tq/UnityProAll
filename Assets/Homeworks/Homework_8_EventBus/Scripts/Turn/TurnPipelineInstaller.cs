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
            _turnPipeline.AddTask(_serviceFactory.Create<StartTurnTask>());
            _turnPipeline.AddTask(_serviceFactory.Create<StartVisualPipelineTask>());
            _turnPipeline.AddTask(_serviceFactory.Create<СhoiceOpponentHeroTask>());
            _turnPipeline.AddTask(_serviceFactory.Create<PreAttackTask>());
            //_turnPipeline.AddTask(_serviceFactory.Create<AttackTask>());
            //_turnPipeline.AddTask(_serviceFactory.Create<PostAttackTask>());
            //_turnPipeline.AddTask(_serviceFactory.Create<EndTurnTask>());
            //_turnPipeline.AddTask(new FinishTurnTask());
        }

        void IDisposable.Dispose()
        {
            _turnPipeline.ClearTasks();
        }
    }
}