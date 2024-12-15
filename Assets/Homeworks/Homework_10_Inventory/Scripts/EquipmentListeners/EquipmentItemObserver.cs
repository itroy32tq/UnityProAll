using Assets.Homeworks.Homework_10_Inventory;
using System;
using Zenject;

namespace GameEngine
{
    internal sealed class EquipmentItemObserver<T> : IInitializable, IDisposable where T : IEquipmentComponent
    {
        private readonly Character _player;
        private readonly IEquipment _equipment;

        public EquipmentItemObserver(Character player, IEquipment equipment)
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