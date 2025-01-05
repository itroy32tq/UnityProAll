using Zenject;

namespace Assets.Homeworks.Homework_10_Inventory
{
    internal sealed class InventorySystemInstaller : Installer<InventorySystemInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IInventory>().
                FromInstance(new Inventory()).
                AsSingle().
                NonLazy();
        }
    }
}