using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    [Serializable]
    internal sealed class MoveInput
    {

        public event Action<Vector3> OnInputMovingHandler;

        private Vector3 _direction;

        public void Update()
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


            OnInputMovingHandler.Invoke(_direction);

        }

    }
}
