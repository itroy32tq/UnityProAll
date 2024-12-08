using Atomic.Elements;
using Declarative;
using UnityEngine;

namespace Assets.Homeworks.Homework_9_UpgradeManager
{
    public class ConveyorModel : DeclarativeModel
    {
        public AtomicVariable<int> LoadStorageCapacity;
        public AtomicVariable<int> UnloadStorageCapacity;
        public AtomicVariable<float> ProduceTime;

        [SerializeReference] private IExample[] _examples;
    }
}