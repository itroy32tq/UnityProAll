using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    [CreateAssetMenu(
        fileName = "ZombietSpawnerConfig",
        menuName = "Zombie/New ZombieSpawnerConfig"
    )]

    internal sealed class ZombieSpawnerConfig : ScriptableObject
    {
        [field: SerializeField] public Transform Container { get; private set; }
        [field: SerializeField] public Zombie Zombie { get; private set; }
        [field: SerializeField] public int InitialCount { get; private set; }
    }
}