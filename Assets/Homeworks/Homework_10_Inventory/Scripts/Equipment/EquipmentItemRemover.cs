namespace Assets.Homeworks.Homework_10_Inventory
{
    internal sealed class EquipmentItemRemover
    {
        private readonly Equipment _equipment;

        public EquipmentItemRemover(Equipment equipment)
        {
            _equipment = equipment;
        }

        public bool TryRemoveItem(EquipmentType type)
        {
            if (_equipment.TryGetItem(type, out var item))
            {
                _equipment.OnItemRemoved.Invoke(item);

                _equipment.EquipmentItems.Remove(type);

                return true;
            }

            return false;
        }

        public void RemoveItem(EquipmentType type)
        {
            var item = _equipment.EquipmentItems[type];

            _equipment.OnItemRemoved.Invoke(item);

            _equipment.EquipmentItems.Remove(type);
        }
    }
}
