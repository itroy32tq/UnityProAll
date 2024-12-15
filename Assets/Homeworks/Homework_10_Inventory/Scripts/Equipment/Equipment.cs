using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Homeworks.Homework_10_Inventory
{
    internal sealed class Equipment
    {
        public Action<Item> OnItemAdded = delegate { };
        public Action<Item> OnItemRemoved = delegate { };
        public Action<Item> OnItemChanged = delegate { }; 

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