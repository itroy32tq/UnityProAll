using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;

namespace Assets.Homeworks.Homework_10_Inventory
{
    internal sealed class Inventory
    {
        public Action<Item> OnItemAdded = delegate { };
        public Action<Item> OnItemRemoved = delegate { };
        public Action<Item> OnItemConsumed = delegate { };

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

        public int GetCount(string item)
        {
            return _items.Count(it => it.Name == item);
        }
    }
}