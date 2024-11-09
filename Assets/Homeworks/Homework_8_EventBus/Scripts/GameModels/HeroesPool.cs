using UnityEngine;

namespace Assets.Homeworks.Homework_8_EventBus
{

    [CreateAssetMenu(fileName = "HeroesPool", menuName = "Data/EventBusHeroesPool")]
    internal sealed class HeroesPool : ScriptableObject
    {
        [field: SerializeField] public Hero[] RedHeroes { get; private set; }

        [field: SerializeField] public Hero[] BluHeroes { get; private set; }

    }
}
