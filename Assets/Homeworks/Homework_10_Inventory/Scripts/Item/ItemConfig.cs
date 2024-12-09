using UnityEngine;

namespace Assets.Homeworks.Homework_10_Inventory
{
    [CreateAssetMenu(
        fileName = "ItemConfig",
        menuName = "Inventory/New InventoryItemConfig"
    )]
    internal sealed class ItemConfig : ScriptableObject
    {
        [field: SerializeField] public Item Item { get; private set; }

        public Item InstantiateItem()
        {
            return Item.Clone();
        }
    }
}