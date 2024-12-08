using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_10_Inventory
{

    [Serializable]
    internal sealed class PowerComponent : IItemComponent
    {
        public int Power => this.power;
        
        [SerializeField]
        private int power;
        
        public IItemComponent Clone()
        {
            return this;
        }
    }
}