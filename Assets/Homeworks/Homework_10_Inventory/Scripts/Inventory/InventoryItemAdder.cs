namespace Assets.Homeworks.Homework_10_Inventory
{
    internal sealed class InventoryItemAdder
    {
        private readonly Inventory _inventory;

        public InventoryItemAdder(Inventory inventory)
        {
            _inventory = inventory;
        }

        public void AddItem(Item item)
        {
            if (!_inventory.Items.Contains(item))
            {
                _inventory.Items.Add(item);

                _inventory.OnItemAdded?.Invoke(item);
            }
        }
    }
}