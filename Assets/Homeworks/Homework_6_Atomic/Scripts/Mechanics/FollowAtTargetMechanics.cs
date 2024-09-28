using Atomic.Elements;
using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class FollowAtTargetMechanics
    {
        private readonly IAtomicAction<Vector3> _rotateAction;
        private readonly IAtomicValue<Vector3> _targetPoint;
        private readonly IAtomicValue<Vector3> _transform;

        private readonly CompositeCondition _condition = new();

        public FollowAtTargetMechanics(

            IAtomicAction<Vector3> _action,
            IAtomicValue<Vector3> targetPoint,
            IAtomicValue<Vector3> transform)
        {
            _rotateAction = _action;
            _targetPoint = targetPoint;
            _transform = transform;
        }

        public void Update()
        {
            if (!_condition.IsTrue())
            {
                _rotateAction.Invoke(Vector3.zero);
                return;
            }

            var direction = _targetPoint.Value - _transform.Value;
            _rotateAction.Invoke(direction.normalized);
        }

        public void AppendCondition(Func<bool> condition)
        {
            _condition.AddCondition(condition);
        }
    }
}
