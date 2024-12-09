using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Assets.Homeworks.Homework_10_Inventory
{
    internal sealed class EquipmentDebug : MonoBehaviour
    {
        private InventoryItemAdder _inventoryItemAdder;
        private EquipmentItemAdder _equipmentItemAdder;
        private Inventory _inventory;


        [Inject]
        public void Construct(InventoryItemAdder inventoryItemAdder, EquipmentItemAdder equipmentItemAdder, Inventory inventory)
        { 
            _inventoryItemAdder = inventoryItemAdder;
            _equipmentItemAdder = equipmentItemAdder;
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
                if (_equipmentItemAdder.TryEquipItem(item))
                {
                    Debug.Log($" Item equiped ");
                }
            }
        }
    }
}