using System.Collections.Generic;
using UnityEngine;

namespace Assets.Homeworks.Homework_8_EventBus
{
    [CreateAssetMenu(fileName = "Hero", menuName = "Data/Hero")]
    public sealed class Hero : ScriptableObject
    {
        public List<Effect> Effects { get; set; } = new List<Effect>();

        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public int Attack { get; private set; }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }
    }
}
