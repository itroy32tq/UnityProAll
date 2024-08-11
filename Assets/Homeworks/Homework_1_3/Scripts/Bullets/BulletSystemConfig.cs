using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(
        fileName = "BulletSystemConfig",
        menuName = "Bullets/New BulletSystemConfig"
    )]
    public sealed class BulletSystemConfig : ScriptableObject
    {
        [field: SerializeField] public int InitialCount { get; private set; }
        [field: SerializeField] public Transform Container { get; private set; }
    }
}
    