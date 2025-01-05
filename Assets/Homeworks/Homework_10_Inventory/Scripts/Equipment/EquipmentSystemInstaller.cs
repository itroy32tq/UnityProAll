using GameEngine;
using Zenject;

namespace Assets.Homeworks.Homework_10_Inventory
{
    internal sealed class EquipmentSystemInstaller : Installer<EquipmentSystemInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IEquipment>().
                FromInstance(new Equipment()).
                AsSingle().
                NonLazy();

            Container.BindInterfacesAndSelfTo<EquipmentItemObserver<ArmorComponent>>().
                AsSingle().
                NonLazy();

            Container.BindInterfacesAndSelfTo<EquipmentItemObserver<PowerComponent>>().
                AsSingle().
                NonLazy();

            Container.BindInterfacesAndSelfTo<EquipmentItemObserver<SpeedComponent>>().
                AsSingle().
                NonLazy();
        }
    }
}
