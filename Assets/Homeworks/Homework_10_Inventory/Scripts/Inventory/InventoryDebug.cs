using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Assets.Homeworks.Homework_10_Inventory
{
    internal sealed class InventoryDebug : MonoBehaviour
    {
        private InventoryItemAdder _inventoryItemAdder;

        private InventoryItemConsumer _itemConsumer;

        [Inject]
        public void Construct(InventoryItemConsumer inventoryItemConsumer, InventoryItemAdder inventoryItemAdder)
        { 
            _inventoryItemAdder = inventoryItemAdder;
            _itemConsumer = inventoryItemConsumer;
        }

        [Button]
        public void AddItem(ItemConfig config)
        {
            Item item = config.InstantiateItem();

            _inventoryItemAdder.AddItem(item);

            Debug.Log($" Item added ");
        }

        [Button]
        public void ConsumeItem(Item item)
        {
            //bool success = _itemConsumer.Consume(position);
            //Debug.Log($"Item consumed {success}");
        }
    }
}