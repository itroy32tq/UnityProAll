using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_10_Inventory
{
    [Serializable]
    internal sealed class HealingComponent : IItemComponent
    {
        [field: SerializeField]
        public int HealingPoints { get; set; } = 2;
        
        public IItemComponent Clone()
        {
            return this;
        }
    }
}