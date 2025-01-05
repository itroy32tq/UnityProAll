using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_10_Inventory
{
    [Serializable]
    internal sealed class EquipmentComponent : IItemComponent
    {
        [field: SerializeField] public EquipmentType EquipType { get; private set; }

        public IItemComponent Clone()
        {
            return new EquipmentComponent();
        }

    }
}
