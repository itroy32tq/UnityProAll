using System;
using UnityEngine;
using Zenject;

namespace Assets.Homeworks.Homework_10_Inventory
{
    internal sealed class InventoryItemHealObserver : IInitializable, IDisposable
    {
        private readonly Inventory _inventory;
        private readonly Character _player;

        public InventoryItemHealObserver(Inventory inventory, Character player)
        {
            _inventory = inventory;
            _player = player;
        }

        public void Initialize()
        {
            _inventory.OnItemConsumed += this.OnItemConsumed;
        }

        public void Dispose()
        {
            _inventory.OnItemConsumed -= this.OnItemConsumed;
        }

        private void OnItemConsumed(Item item)
        {
            if (item.TryGetComponent(out HealingComponent healingComponent))
            {
                _player.Health += healingComponent.HealingPoints;

                Debug.Log($"HEALING: +{healingComponent.HealingPoints}");
            }
        }
    }
}