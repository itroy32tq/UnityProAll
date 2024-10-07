using Atomic.Elements;
using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    [Serializable]
    internal sealed class MoveComponent
    {
        public AtomicVariable<Vector3> MoveDirection;
        public AtomicVariable<bool> IsMoving;
        public AtomicValue<Transform> MoveRoot;
        public AtomicValue<float> MoveSpeed;

        [SerializeField] private Transform _root;
        [SerializeField] private float _speed = 3f;

        private readonly AtomicAnd _canMove = new();

        public AtomicAnd CanMove => _canMove;

        public void Compose()
        {
            MoveDirection.Subscribe(moveDirection =>
            {
                IsMoving.Value = moveDirection != Vector3.zero;
            });

            MoveRoot = new AtomicValue<Transform>(_root);
            MoveSpeed = new AtomicValue<float>(_speed);

        }

        public void AppendCondition(IAtomicValue<bool> condition)
        {
            _canMove.Append(condition);
        }
    }
}
