using System;
using Zenject;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class TurnPipelineInstaller : MonoInstaller, IInitializable, IDisposable
    {
        private TurnPipeline _turnPipeline;
        private IServiceFactory _serviceFactory;

        [Inject]
        public void Construct(TurnPipeline turnPipeline, IServiceFactory serviceFactory)
        {
            _turnPipeline = turnPipeline;
            _serviceFactory = serviceFactory;
        }

        void IInitializable.Initialize()
        {
            _turnPipeline.AddTask(_serviceFactory.Create<StartTurnTask>());
            _turnPipeline.AddTask(_serviceFactory.Create<СhoiceOpponentHeroTask>());
            _turnPipeline.AddTask(_serviceFactory.Create<PreAttackTask>());
        }

        void IDisposable.Dispose()
        {
            _turnPipeline.ClearTasks();
        }

        public override void InstallBindings()
        {
            Container.
                Bind<TurnPipeline>().
                To<TurnPipeline>().
                AsSingle();

            Container.
                Bind<AttackTask>().
                To<AttackTask>().
                AsTransient();

            Container.
                Bind<EndTurnTask>().
                To<EndTurnTask>().
                AsTransient();

            Container.
                Bind<PostAttackTask>().
                To<PostAttackTask>().
                AsTransient();

            Container.
                Bind<PreAttackTask>().
                To<PreAttackTask>().
                AsTransient();

            Container.
                Bind<StartTurnTask>().
                To<StartTurnTask>().
                AsTransient();

            Container.
                Bind<СhoiceOpponentHeroTask>().
                To<СhoiceOpponentHeroTask>().
                AsTransient();
        }

    }
}