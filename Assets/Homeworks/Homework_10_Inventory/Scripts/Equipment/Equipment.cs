using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Homeworks.Homework_10_Inventory
{
    internal sealed class Equipment : IEquipment
    {
        public event Action<Item> OnItemAdded = delegate { };
        public event Action<Item> OnItemRemoved = delegate { };
        public event Action<Item> OnItemChanged = delegate { };

        private readonly Dictionary<EquipmentType, Item> _equipmentItems = new();

        public Dictionary<EquipmentType, Item> EquipmentItems => _equipmentItems;

        public Item GetItem(EquipmentType type)
        {
            if (_equipmentItems.TryGetValue(type, out var item))
            {
                return item;
            }

            throw new Exception();
        }

        public void AddItem(EquipmentType type, Item item)
        {
            EquipmentItems.Add(type, item);

            OnItemAdded.Invoke(item);
        }

        public void RemoveItem(EquipmentType type)
        {
            var item = EquipmentItems[type];

            OnItemRemoved.Invoke(item);

            EquipmentItems.Remove(type);
        }

        public bool TryGetItem(EquipmentType type, out Item result)
        {
            if (_equipmentItems.TryGetValue(type, out var item))
            {
                result = item;
                return true;
            }

            result = default;

            return false;
        }

        public bool HasItem(EquipmentType type)
        {
            return _equipmentItems.ContainsKey(type);
        }

        public KeyValuePair<EquipmentType, Item>[] GetItems()
        {
            return _equipmentItems.ToArray();
        }
    }
}