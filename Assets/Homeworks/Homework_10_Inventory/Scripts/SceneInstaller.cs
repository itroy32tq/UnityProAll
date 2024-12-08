using Zenject;

namespace Assets.Homeworks.Homework_10_Inventory
{
    internal  sealed class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InventorySystemInstaller.Install(Container);
        }
    }
}
