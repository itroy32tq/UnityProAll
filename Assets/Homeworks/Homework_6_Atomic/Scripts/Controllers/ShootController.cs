using System;
using UnityEngine;
using Zenject;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class ShootController : ITickable
    {
        public event Action OnInputShootingHandler = delegate { };

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnInputShootingHandler.Invoke();
            }
        }
    }
}
