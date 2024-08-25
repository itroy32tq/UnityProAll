using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    [Serializable]
    internal sealed class ShootInput 
    {
        public event Action OnInputShootingHandler = delegate { };

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnInputShootingHandler.Invoke();
            }
        }
    }
}
