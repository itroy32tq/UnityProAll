using Zenject;

namespace Assets.Homeworks.Homework_10_Inventory
{
    internal sealed class InventorySystemInstaller : Installer<InventorySystemInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<Inventory>().
                FromInstance(new Inventory()).
                AsSingle().
                NonLazy();

            Container.Bind<InventoryItemAdder>().
                AsSingle().
                NonLazy();

            Container.Bind<InventoryItemRemover>().
                AsSingle().
                NonLazy();

            Container.Bind<InventoryItemConsumer>().
                AsSingle().
                NonLazy();
        }
    }
}