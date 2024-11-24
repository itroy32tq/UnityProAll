using UnityEngine;

namespace Assets.Homeworks.Homework_8_EventBus
{
    [CreateAssetMenu(fileName = "RandomAttackEffect", menuName = "Data/RandomAttackEffect")]
    public sealed class RandomAttackEffectConfig : ScriptableObject, IEffectConfig
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public GameState State { get; private set; }

        public Hero Source { get; set; }

        public Hero Target { get; set; }
    }
}
