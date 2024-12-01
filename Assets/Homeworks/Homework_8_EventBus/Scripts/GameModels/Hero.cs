using System.Collections.Generic;

namespace Assets.Homeworks.Homework_8_EventBus
{
    public sealed class Hero
    {
        public List<string> Effects { get; private set; }
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Attack { get; private set; }
        public bool IsDamageImmune { get; internal set; }

        public Hero(HeroInfo heroInfo)
        {
            Name = heroInfo.Name;
            Health = heroInfo.Health;
            Attack = heroInfo.Attack;

            Effects = heroInfo.Effects;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void SetDammgeImmune(bool value)
        { 
            IsDamageImmune = value;
        }
    }
}
