using System;

namespace Assets.Homeworks.Homework_10_Inventory
{
    [Serializable]
    internal sealed class StackableComponent : IItemComponent
    {
        public int current;
        public int max;
        
        public IItemComponent Clone()
        {
            return new StackableComponent
            {
                current = this.current,
                max = this.max
            };
        }
    }
}