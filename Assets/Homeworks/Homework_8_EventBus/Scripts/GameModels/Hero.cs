using System.Collections.Generic;

namespace Assets.Homeworks.Homework_8_EventBus
{
    public sealed class Hero
    {
        public List<Effect> Effects { get; set; } = new List<Effect>();
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Attack { get; private set; }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }
    }
}
