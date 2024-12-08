using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;

namespace Assets.Homeworks.Homework_10_Inventory
{
    internal sealed class Character
    {
        public event Action OnStateChanged;
        
        [ShowInInspector, ReadOnly]
        private readonly Dictionary<string, int> stats;

        public int Damage { get; internal set; }
        public int Health { get; internal set; }

        public Character()
        {
            this.stats = new Dictionary<string, int>();
        }

        public Character(params KeyValuePair<string, int>[] stats)
        {
            this.stats = new Dictionary<string, int>(stats);
        }

        public int GetStat(string name)
        {
            return this.stats[name];
        }

        public void SetStat(string name, int value)
        {
            this.stats[name] = value;
            this.OnStateChanged?.Invoke();
        }

        public void RemoveStat(string name, int value)
        {
            if (this.stats.Remove(name))
            {
                this.OnStateChanged?.Invoke();
            }
        }

        public KeyValuePair<string, int>[] GetStats()
        {
            return this.stats.ToArray();
        }
    }
}