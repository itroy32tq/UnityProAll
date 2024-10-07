using Atomic.Elements;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    [Serializable]
    internal sealed class RotationComponent
    {
        public AtomicAction<Vector3> RotateAction;
        public Transform RotationRoot => _rotationRoot;

        [SerializeField] private Transform _rotationRoot;
        [SerializeField] private Vector3 _rotateDirection;
        [SerializeField] private float _rotateRate;
        private readonly AtomicAnd _canRotate = new();


        public void Compose()
        {
            RotateAction.Compose(Rotate);
        }

        public void Rotate(Vector3 forwardDirection)
        {
            _rotateDirection = forwardDirection;

            if (!_canRotate.Invoke())
            {
                return;
            }

            if (forwardDirection == Vector3.zero)
            {
                return;
            }

            var targetRotation = Quaternion.LookRotation(_rotateDirection, Vector3.up);
            _rotationRoot.rotation = Quaternion.Lerp(_rotationRoot.rotation, targetRotation, _rotateRate);
        }

        public void AppendCondition(IAtomicValue<bool> condition)
        {
            _canRotate.Append(condition);
        }
    }
}
