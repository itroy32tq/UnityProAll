using System;

namespace Assets.Homeworks.Homework_10_Inventory
{
    internal sealed class InventoryItemConsumer
    {
        private readonly Inventory _inventory;
        private readonly InventoryItemRemover _itemRemover;

        public InventoryItemConsumer(Inventory inventory, InventoryItemRemover itemRemover)
        {
            _inventory = inventory;

            _itemRemover = itemRemover;
        }

        public bool CanConsume(Item item)
        {
            if ((item.Flags & ItemFlags.CONSUMABLE) != ItemFlags.CONSUMABLE)
            {
                return false;
            }

            if (!_itemRemover.CanRemove(item))
            {
                return false;
            }

            return true;
        }

        public bool Consume(Item item)
        {
            if (!CanConsume(item))
            {
                return false;
            }
            
            _itemRemover.RemoveItem(item);

            _inventory.OnItemConsumed?.Invoke(item);

            return true;
        }
    }
}