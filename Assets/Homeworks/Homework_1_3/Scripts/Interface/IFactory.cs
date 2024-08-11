using UnityEngine;

namespace ShootEmUp
{
    public interface IFactory<out T>
    {
        T Create();
    }
}
