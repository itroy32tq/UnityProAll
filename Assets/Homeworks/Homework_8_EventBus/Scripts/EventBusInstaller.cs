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
                Bind<AttackHandler>().
                To<AttackHandler>().
                AsSingle();

            Container.
                Bind<SwithStateHandler>().
                To<SwithStateHandler>().
                AsSingle();
        }
    }
}
