using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_10_Inventory
{
    [Serializable]
    internal sealed class Item
    {
        [field: SerializeField] public string Name { get; private set;}
        [field: SerializeField] public string Description { get; set; }
        [field: SerializeField] public Sprite Icon { get; set; }
        [field: SerializeField] public ItemFlags Flags { get; set; }

        [SerializeReference]
        private IItemComponent[] _components;

        public T GetComponent<T>()
        {
            foreach (var component in _components)
            {
                if (component is T tComponent)
                {
                    return tComponent;
                }
            }

            throw new Exception($"Component of type {typeof(T).Name} is not found!");
        }

        public bool TryGetComponent<T>(out T component)
        {
            for (int i = 0, count = _components.Length; i < count; i++)
            {
                if (_components[i] is T tComponent)
                {
                    component = tComponent;
                    return true;
                }
            }

            component = default;

            return false;
        }

        public Item Clone()
        {
            return new Item
            {
                Name = Name,
                Description = Description,
                Icon = Icon,
                Flags = Flags,
                _components = CloneComponents()
            };
        }

        private IItemComponent[] CloneComponents()
        {
            int length = _components.Length;

            var result = new IItemComponent[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = _components[i].Clone();
            }

            return result;
        }
    }
}