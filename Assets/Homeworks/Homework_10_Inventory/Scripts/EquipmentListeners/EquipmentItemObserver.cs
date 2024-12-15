using Assets.Homeworks.Homework_10_Inventory;
using System;
using Zenject;

namespace GameEngine
{
    internal sealed class EquipmentItemObserver<T> : IInitializable, IDisposable where T : IItemComponent
    {
        private readonly Character _player;
        private readonly Equipment _equipment;

        public EquipmentItemObserver(Character player, Equipment equipment)
        {
            _player = player;
            _equipment = equipment;
        }

        public void Initialize()
        {
            _equipment.OnItemAdded += OnItemAdded;

            _equipment.OnItemRemoved += OnItemRemoved;
        }

        public void Dispose()
        {
            _equipment.OnItemAdded -= OnItemAdded;

            _equipment.OnItemRemoved -= OnItemRemoved;
        }

        private void OnItemAdded(Item item)
        {
            if (item.TryGetComponent(out T component))
            {
                component.ApplayEffect(_player);
            }
        }

        private void OnItemRemoved(Item item)
        {
            if (item.TryGetComponent(out T component))
            {
                component.ResetEffect(_player);
            }
        }
    }
}