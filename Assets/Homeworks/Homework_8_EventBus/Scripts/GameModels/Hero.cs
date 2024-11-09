using System.Collections.Generic;
using UnityEngine;

namespace Assets.Homeworks.Homework_8_EventBus
{

    public sealed class Hero
    {
        public List<Effect> Effects { get; set; } = new List<Effect>();

        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public int Attack { get; private set; }

        public Hero(HeroInfo heroInfo)
        {
            Name = heroInfo.Name;
            Health = heroInfo.Health;
            Attack = heroInfo.Attack;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }
    }
}
