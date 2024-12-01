using Atomic.Elements;

namespace Assets.Homeworks.Homework_9_UpgradeManager
{
    public class Conveyor_SetUnloadStorageComponent : IConveyor_SetUnloadStorageComponent 
    {
        private readonly AtomicVariable<int> _unloadStorage;

        public Conveyor_SetUnloadStorageComponent(AtomicVariable<int> unloadStorage)
        {
            _unloadStorage = unloadStorage;
        }

        public void SetUnloadStorage(int value)
        {
            _unloadStorage.Value = value;
        }
    }
}