using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Assets.Homeworks.Homework_10_Inventory
{
    internal sealed class EquipmentDebug : MonoBehaviour
    {
        private IInventory _inventory;
        private IEquipment _equipment;


        [Inject]
        public void Construct(IEquipment equipment, IInventory inventory)
        { 

            _equipment = equipment;
            _inventory = inventory;
        }

        [Button]
        public void AddItem(ItemConfig config)
        {
            Item item = config.InstantiateItem();

            _inventory.TryAddItem(item);

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