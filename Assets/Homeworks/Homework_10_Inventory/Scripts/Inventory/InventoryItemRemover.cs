namespace Assets.Homeworks.Homework_10_Inventory
{
    internal sealed class InventoryItemRemover
    {
        private readonly Inventory _inventory;

        public InventoryItemRemover(Inventory inventory)
        {
            _inventory = inventory;
        }

        public void RemoveItem(Item item)
        {
            if (_inventory.Items.Remove(item))
            {
                _inventory.OnItemRemoved?.Invoke(item);
            }
        }

        public void RemoveItems(string name, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RemoveItem(name);
            }
        }

        public void RemoveItem(string name)
        {
            if (_inventory.FindItem(name, out var item))
            {
                RemoveItem(item);
            }
        }

        internal bool CanRemove(Item item)
        {
            if (_inventory.Items.Remove(item))
            {
                _inventory.OnItemRemoved?.Invoke(item);

                return true;
            }

            return false;
        }
    }
}