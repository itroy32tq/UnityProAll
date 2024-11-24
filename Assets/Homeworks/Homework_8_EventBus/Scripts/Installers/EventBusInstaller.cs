using Zenject;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class EventBusInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.
                Bind<EventBus>().
                To<EventBus>().
                AsSingle();

            Container.
                BindInterfacesAndSelfTo<AttackHandler>().
                AsSingle();

            Container.
                BindInterfacesAndSelfTo<SwithStateHandler>().
                AsSingle();

            Container.
                BindInterfacesAndSelfTo<CheckHeroesHelthHandler>().
                AsSingle();

            Container.
               BindInterfacesAndSelfTo<RemoveHeroHandler>().
               AsSingle();
        }
    }
}
