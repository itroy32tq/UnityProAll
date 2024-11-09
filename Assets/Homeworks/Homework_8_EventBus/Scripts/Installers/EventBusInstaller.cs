using Zenject;

namespace Assets.Homeworks.Homework_8_EventBus.Scripts
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
                BindInterfacesAndSelfTo<DealDamageVisualHandler>().
                AsSingle();

            Container.
                BindInterfacesAndSelfTo<AttackVisualHandler>().
                AsSingle();

            Container.
                BindInterfacesAndSelfTo<DestroyVisualHandler>().
                AsSingle();
        }
    }
}
