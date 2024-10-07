using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class MoveInput
    {
        public event Action<Vector3> OnInputMovingHandler = delegate { };

        private Vector3 _direction;

        public void Update()
        {
            _direction = Vector3.zero;

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Возвращаем направление движения на основе ввода
            _direction =  new Vector3(horizontalInput, 0, verticalInput);

            OnInputMovingHandler.Invoke(_direction);
        }

    }
}
