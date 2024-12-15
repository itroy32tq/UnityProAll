using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_10_Inventory
{
    [Serializable]
    internal sealed class SpeedComponent : IItemComponent
    {
        [field: SerializeField] public int Speed { get; private set; } = 7;

        public IItemComponent Clone()
        {
            return this;
        }

        public void ApplayEffect(Character player)
        {
            player.Speed += Speed;

            Debug.Log($" Added {nameof(Speed)}: {Speed} ");
        }

        public void ResetEffect(Character player)
        {
            player.Speed -= Speed;

            Debug.Log($" Removed {nameof(Speed)}: {Speed} ");
        }


    }
}
