
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic.Scripts
{
    internal sealed class Factory<T> : IFactory<T> where T : MonoBehaviour
    {
        private readonly T _prefab;
        private readonly Transform _container;

        public Factory(T prefab, Transform transform)
        {
            _prefab = prefab;
            _container = transform;
        }

        public T Create()
        {
            return Object.Instantiate(_prefab, _container);
        }
    }

    public interface IFactory<out T>
    {
        T Create();
    }
}
