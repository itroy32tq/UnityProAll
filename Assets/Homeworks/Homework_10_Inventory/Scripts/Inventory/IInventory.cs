using System;
using System.Collections.Generic;

namespace Assets.Homeworks.Homework_10_Inventory
{
    internal interface IInventory
    {
        List<Item> Items { get; }

        event Action<Item> OnItemAdded;
        event Action<Item> OnItemConsumed;
        event Action<Item> OnItemRemoved;

        bool TryAddItem(Item item);
        bool FindItem(string name, out Item result);
        int GetCount(string item);
        void Setup(params Item[] items);
        bool RemoveItem(Item item);
        void RemoveItem(string name);
        void ConsumeItem(Item item);
    }
}