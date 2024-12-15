using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_10_Inventory
{
    [Serializable]
    internal sealed class ArmorComponent : IEquipmentComponent
    {
        [field: SerializeField] public int Armor { get; private set; } = 2;

       
        public IItemComponent Clone()
        {
            return new ArmorComponent();
        }

        public void ApplayEffect(Character player)
        {
            player.Armor += Armor;

            Debug.Log($" Added {nameof(Armor)}: {Armor} ");
        }

        public void ResetEffect(Character player)
        {
            player.Armor -= Armor;

            Debug.Log($" Removed {nameof(Armor)}: {Armor} ");
        }
    }
}
