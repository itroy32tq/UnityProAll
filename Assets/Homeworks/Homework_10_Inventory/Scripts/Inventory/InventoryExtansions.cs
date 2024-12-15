namespace Assets.Homeworks.Homework_10_Inventory
{
    internal static class InventoryExtansions
    {
        public static bool CanConsume(this IInventory inventory, Item item)
        {
            if ((item.Flags & ItemFlags.CONSUMABLE) != ItemFlags.CONSUMABLE)
            {
                return false;
            }

            if (!inventory.RemoveItem(item))
            {
                return false;
            }

            return true;
        }

        
        public static void RemoveItems(this IInventory inventory, string name, int count)
        {
            for (int i = 0; i < count; i++)
            {
                inventory.RemoveItem(name);
            }
        }

    }
}
