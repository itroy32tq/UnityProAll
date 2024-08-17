using System;
using UnityEngine;
using Zenject;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class MoveController : ITickable, IFixedTickable
    {
        public event Action OnInputShootingHandler;

        public event Action<Vector3> OnInputMovingHandler = delegate { };
        private Vector3 _direction;
       
        public void Tick()
        {
            _direction = Vector3.zero;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                _direction = Vector3.forward;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                _direction = Vector3.back;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                _direction = Vector3.left;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                _direction = Vector3.right;
            }
        }

        public void FixedTick()
        {
            if (_direction == Vector3.zero)
            {
                return;
            }

            OnInputMovingHandler.Invoke(_direction);
        }
    }
}
