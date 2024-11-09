using Lessons.Game.Turn.Visual.Tasks;
using Zenject;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class VisualPipelineInstaller : MonoInstaller
    {
       
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

            Container.
                Bind<DealDamageVisualTask>().
                To<DealDamageVisualTask>().
                AsTransient();

            Container.
                Bind<DestroyVisualTask>().
                To<DestroyVisualTask>().
                AsTransient();
        }
    }
}
