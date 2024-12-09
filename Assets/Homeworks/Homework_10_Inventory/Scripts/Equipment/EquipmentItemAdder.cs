
using UnityEngine;

namespace Assets.Homeworks.Homework_10_Inventory
{
    internal sealed class EquipmentItemAdder
    {
        private readonly Equipment _equipment;
        private readonly EquipmentItemRemover _equipmentItemRemover;

        public EquipmentItemAdder(Equipment equipment, EquipmentItemRemover equipmentItemRemover)
        {
            _equipment = equipment;
            _equipmentItemRemover = equipmentItemRemover;
        }

        public bool TryEquipItem(Item item)
        {
            if ((item.Flags & ItemFlags.EQUPPABLE) != ItemFlags.EQUPPABLE)
            {
                return false;
            }

            if (!item.TryGetComponent<EquipmentComponent>(out var component))
            {
                //кажись если стоит флаг то и компонент должен быть

                throw new System.Exception();
            }

            var equipType = component.EquipType;

            if (_equipment.HasItem(equipType))
            {
                if (_equipment.EquipmentItems[equipType] == item)
                {
                    Debug.Log("this item has already been worn");

                    return false;
                }

                _equipmentItemRemover.RemoveItem(equipType);

            }

            AddItem(equipType, item);

            return true;
        }

        private void AddItem(EquipmentType type, Item item)
        {
            
            _equipment.EquipmentItems.Add(type, item);

            _equipment.OnItemAdded.Invoke(item);
        }
    }
}
