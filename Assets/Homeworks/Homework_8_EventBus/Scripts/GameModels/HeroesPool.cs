using System.Linq;
using UnityEngine;

namespace Assets.Homeworks.Homework_8_EventBus
{

    [CreateAssetMenu(fileName = "HeroesPool", menuName = "Data/EventBusHeroesPool")]
    internal sealed class HeroesPool : ScriptableObject
    {
        [field: SerializeField] public HeroInfo[] RedHeroes { get; private set; }
        [field: SerializeField] public HeroInfo[] BluHeroes { get; private set; }
        public HeroInfo[] AllPool => RedHeroes.Concat(BluHeroes).ToArray();
    }
}
