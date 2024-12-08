using Assets.Homeworks.Homework_10_Inventory;
using System;
using UnityEngine;
using Zenject;

namespace GameEngine
{
    internal sealed class EquipmentItemPowerObserver : IInitializable, IDisposable
    {
        private readonly Character _player;
        private readonly Inventory _inventory;

        public EquipmentItemPowerObserver(Character player, Inventory inventory)
        {
            _player = player;
            _inventory = inventory;
        }

        public void Initialize()
        {
            _inventory.OnItemAdded += OnItemAdded;
            _inventory.OnItemRemoved += OnItemRemoved;
        }

        public void Dispose()
        {
            _inventory.OnItemAdded -= OnItemAdded;
            _inventory.OnItemRemoved -= OnItemRemoved;
        }

        private void OnItemAdded(Item item)
        {
            if (item.TryGetComponent(out PowerComponent powerComponent))
            {
                _player.Damage += powerComponent.Power;

                Debug.Log($"Added Power: {powerComponent.Power} ");
            }
        }

        private void OnItemRemoved(Item item)
        {
            if (item.TryGetComponent(out PowerComponent powerComponent))
            {
                _player.Damage -= powerComponent.Power;
                Debug.Log($"Removed Power: {powerComponent.Power} ");
            }
        }
    }
}