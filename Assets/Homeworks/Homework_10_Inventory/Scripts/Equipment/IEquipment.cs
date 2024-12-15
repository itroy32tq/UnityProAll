using System;
using System.Collections.Generic;

namespace Assets.Homeworks.Homework_10_Inventory
{
    internal interface IEquipment
    {
        event Action<Item> OnItemAdded;
        event Action<Item> OnItemRemoved;
        event Action<Item> OnItemChanged;
        Dictionary<EquipmentType, Item> EquipmentItems { get; }
        Item GetItem(EquipmentType type);
        KeyValuePair<EquipmentType, Item>[] GetItems();
        bool HasItem(EquipmentType type);
        bool TryGetItem(EquipmentType type, out Item result);
        void RemoveItem(EquipmentType type);
        void AddItem(EquipmentType equipType, Item item);
    }
}