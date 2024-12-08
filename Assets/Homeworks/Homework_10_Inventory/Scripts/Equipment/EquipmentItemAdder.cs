using System.Collections.Generic;

namespace Assets.Homeworks.Homework_10_Inventory
{
    internal sealed class EquipmentItemAdder
    {
        private readonly Equipment _equipment;

        public EquipmentItemAdder(Equipment equipment)
        {
            _equipment = equipment;
        }

        public void Setup(KeyValuePair<EquipmentType, Item> itemPair)
        {
            if (_equipment.HasItem(itemPair.Key))
            {
                ChangeItem(itemPair);
            }

            AddItem(itemPair.Key, itemPair.Value);

        }

        private void ChangeItem(KeyValuePair<EquipmentType, Item> itemPair)
        {
            _equipment.EquipmentItems[itemPair.Key] = itemPair.Value;
            _equipment.OnItemChanged.Invoke(itemPair.Value);
        }

        public void AddItem(EquipmentType type, Item item)
        {
            _equipment.EquipmentItems.Add(type, item);

            _equipment.OnItemAdded.Invoke(item);
        }
    }
}
