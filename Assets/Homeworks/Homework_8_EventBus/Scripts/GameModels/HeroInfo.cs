using System.Collections.Generic;
using UnityEngine;

namespace Assets.Homeworks.Homework_8_EventBus
{
    [CreateAssetMenu(fileName = "HeroInfo", menuName = "Data/HeroInfo")]
    public sealed class HeroInfo : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public int Attack { get; private set; }
        [field: SerializeField] public List<string> Effects { get; private set; }
    }
}
