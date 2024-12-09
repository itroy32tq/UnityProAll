using Zenject;

namespace Assets.Homeworks.Homework_10_Inventory
{
    internal  sealed class SceneInstaller : MonoInstaller
    {
        public Character Character = new();

        public override void InstallBindings()
        {
            InventorySystemInstaller.Install(Container);

            EquipmentSystemInstaller.Install(Container);

            Container.Bind<Character>().
                FromInstance(Character).
                AsSingle().
                NonLazy();
        }
    }
}
