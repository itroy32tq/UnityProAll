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

        [SerializeField] private Transform _root;
        [SerializeField] private float _speed = 3f;
        [SerializeField] private bool _canMove;

        private readonly CompositeCondition _condition = new();

        public void Compose()
        {
            MoveDirection.Subscribe(moveDirection =>
            {
                IsMoving.Value = moveDirection != Vector3.zero;
            });
        }

        public void Update(float deltaTime)
        {
            if (_condition.IsTrue() && _canMove)
            {
                _root.position += _speed * deltaTime * MoveDirection.Value;
            }
        }

        public void AppendCondition(Func<bool> condition)
        {
            _condition.AddCondition(condition);
        }
    }
}
