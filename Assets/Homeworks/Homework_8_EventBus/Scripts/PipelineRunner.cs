using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Homeworks.Homework_8_EventBus
{
    public sealed class PipelineRunner : MonoBehaviour, IInitializable, IDisposable
    {
        private TurnPipeline _turnPipeline;
        private VisualPipeline _visualPipeline;
        private IServiceFactory _serviceFactory;

        [Inject]
        private void Construct(TurnPipeline turnPipeline, VisualPipeline visualPipeline, IServiceFactory serviceFactory)
        {
            _turnPipeline = turnPipeline;
            _visualPipeline = visualPipeline;

            _serviceFactory = serviceFactory;

        }

        [Button]
        public void Run()
        {
            _turnPipeline.Run();
        }
        
        private void OnTurnPipelineFinished()
        {
            _turnPipeline.Run();
        }

        void IInitializable.Initialize()
        {
            _turnPipeline.OnFinished += OnTurnPipelineFinished;

            _turnPipeline.AddTask(_serviceFactory.Create<StartTurnTask>());
            _turnPipeline.AddTask(_serviceFactory.Create<СhoiceOpponentHeroTask>());
            _turnPipeline.AddTask(_serviceFactory.Create<PreAttackTask>());

            //_visualPipeline.OnFinished += OnVisualPipelineFinished;

        }

        private async void OnVisualPipelineFinished()
        {
            _visualPipeline.ClearTasks();

            await UniTask.DelayFrame(1);

            _visualPipeline.Run();

        }

        void IDisposable.Dispose()
        {
            _turnPipeline.ClearTasks();

            _visualPipeline.ClearTasks();

            _turnPipeline.OnFinished -= OnTurnPipelineFinished;
        }
    }
}