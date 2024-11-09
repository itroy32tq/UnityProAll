using System;
using Zenject;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class TurnPipelineInstaller : MonoInstaller  
    {
        
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