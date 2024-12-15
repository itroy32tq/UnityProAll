using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_10_Inventory
{
    [Serializable]
    internal sealed class PowerComponent : IEquipmentComponent
    {
        [field: SerializeField] public int Power { get; private set; } = 5;

        
        public IItemComponent Clone()
        {
            return new PowerComponent();
        }

        public void ApplayEffect(Character player)
        {
            player.Damage += Power;
            player.OnApplyEffect.Invoke(true);

            Debug.Log($" Added {nameof(Power)}: {Power} ");
        }

        public void ResetEffect(Character player)
        {
            player.Damage -= Power;
            player.OnApplyEffect.Invoke(false);

            Debug.Log($" Removed {nameof(Power)}: {Power} ");
        }
    }
}