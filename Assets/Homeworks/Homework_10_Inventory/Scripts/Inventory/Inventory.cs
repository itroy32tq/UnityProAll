using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;

namespace Assets.Homeworks.Homework_10_Inventory
{
    internal sealed class Inventory : IInventory
    {
        public event Action<Item> OnItemAdded = delegate { };
        public event Action<Item> OnItemRemoved = delegate { };
        public event Action<Item> OnItemConsumed = delegate { };

        [ShowInInspector, ReadOnly]
        private List<Item> _items;
        public List<Item> Items => _items;

        public Inventory(params Item[] items)
        {
            _items = new List<Item>(items);
        }

        public void Setup(params Item[] items)
        {
            _items = new(items);
        }

        public void RemoveItem(string name)
        {
            if (FindItem(name, out var item))
            {
                RemoveItem(item);
            }
        }

        public bool FindItem(string name, out Item result)
        {
            foreach (var inventoryItem in _items)
            {
                if (inventoryItem.Name == name)
                {
                    result = inventoryItem;

                    return true;
                }
            }

            result = null;
            return false;
        }

        public void ConsumeItem(Item item)
        {
            RemoveItem(item);

            OnItemConsumed?.Invoke(item);
        }

        public bool RemoveItem(Item item)
        {
            if (_items.Remove(item))
            {
                OnItemRemoved.Invoke(item);

                return true;
            }

            return false;
        }

        public int GetCount(string item)
        {
            return _items.Count(it => it.Name == item);
        }

        public bool TryAddItem(Item item)
        {
            if (!_items.Contains(item))
            {
                _items.Add(item);

                OnItemAdded.Invoke(item);

                return true;
            }

            return false;
        }
    }
}