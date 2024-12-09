using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_10_Inventory
{
    [Serializable]
    internal sealed class EquipmentComponent : IItemComponent
    {
        [field: SerializeField] public EquipmentType EquipType { get; private set; }

        public void ApplayEffect(Character character)
        {
            throw new NotImplementedException();
        }

        public IItemComponent Clone()
        {
            return new EquipmentComponent();
        }

        public void ResetEffect(Character character)
        {
            throw new NotImplementedException();
        }
    }
}
