using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class Pool<T> where T : MonoBehaviour
    {
        private readonly Queue<T> _items;
        private readonly PlaceholderFactory<T> _factory;

        public Pool(int size, DiContainer diContainer)
        {
            _items = new Queue<T>(size);
            _factory = diContainer.Resolve<PlaceholderFactory<T>>();

            for (int i = 0; i < size; i++)
            {
                T item = _factory.Create();
                item.gameObject.SetActive(false);
                _items.Enqueue(item);
            }
        }

        private bool HasFreeElement(out T element)
        {
            element = _items?
                .FirstOrDefault(x => !x.isActiveAndEnabled);
            element?.gameObject.SetActive(true);
            return element != null;
        }

        public bool TryGet(out T elem)
        {
            if (HasFreeElement(out T element))
            {
                elem = element;
                return true;
            }
            else
            {
                elem = null;
                return false;
            }
        }

        public void Release(T item)
        {
            item.gameObject.SetActive(false);
        }
    }
}
