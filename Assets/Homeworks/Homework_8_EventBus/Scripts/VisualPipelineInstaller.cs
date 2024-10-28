using System;
using Zenject;

namespace Assets.Homeworks.Homework_8_EventBus.Scripts
{
    internal sealed class VisualPipelineInstaller : MonoInstaller, IInitializable, IDisposable
    {
        private VisualPipeline _visualPipeline;
        private IServiceFactory _serviceFactory;


        [Inject]
        public void Construct(VisualPipeline visualPipeline, IServiceFactory serviceFactory)
        {
            _visualPipeline = visualPipeline;
            _serviceFactory = serviceFactory;
        }

        void IInitializable.Initialize()
        {
            _visualPipeline.AddTask(_serviceFactory.Create<StartVisualPipelineTask>());

        }

        public override void InstallBindings()
        {

            Container.
                Bind<VisualPipeline>().
                To<VisualPipeline>().
                AsSingle();

            Container.
                Bind<AttackVisualTask>().
                To<AttackVisualTask>().
                AsTransient();

            Container.
                Bind<StartVisualPipelineTask>().
                To<StartVisualPipelineTask>().
                AsTransient();
        }

        public void Dispose()
        {
            _visualPipeline.ClearTasks();
        }
    }
}
