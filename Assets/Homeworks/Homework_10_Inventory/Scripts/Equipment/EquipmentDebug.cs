using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Assets.Homeworks.Homework_10_Inventory
{
    internal sealed class EquipmentDebug : MonoBehaviour
    {
        private InventoryItemAdder _inventoryItemAdder;
        private Inventory _inventory;
        private IEquipment _equipment;


        [Inject]
        public void Construct(InventoryItemAdder inventoryItemAdder, IEquipment equipment, Inventory inventory)
        { 
            _inventoryItemAdder = inventoryItemAdder;
            _equipment = equipment;
            _inventory = inventory;
        }

        [Button]
        public void AddItem(ItemConfig config)
        {
            Item item = config.InstantiateItem();

            _inventoryItemAdder.AddItem(item);

            Debug.Log($" Item added ");
        }

        [Button]
        public void EquipItem(string name)
        {
            if (_inventory.FindItem(name, out var item))
            {
                if (_equipment.TryEquipItem(item))
                {
                    Debug.Log($" Item equiped ");
                }
            }
        }
    }
}