using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    [CreateAssetMenu(
        fileName = "AtomicBulletSystemConfig",
        menuName = "Bullets/New AtomicBulletSystemConfig"
    )]
    internal sealed class BulletSystemConfig : ScriptableObject
    {
        [field: SerializeField] public int InitialCount { get; private set; }
        [field: SerializeField] public Transform Container { get; private set; }
        [field: SerializeField] public Bullet Bullet { get; private set; }
    }
}
