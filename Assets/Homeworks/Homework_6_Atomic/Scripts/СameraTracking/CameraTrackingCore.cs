using Atomic.Elements;
using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    [Serializable]
    internal sealed class CameraTrackingCore
    {
        private Transform _targetPoint;
        private Transform _root;
        private FollowAtTargetMechanics _lookAtTargetMechanics;
        private FollowAtTargetMechanics _followToTargetMechanics;

        [SerializeField] private float _followDistance;

        [field: SerializeField] public MoveComponent MoveComponent { get; private set; }
        [field: SerializeField] public RotationComponent RotationComponent { get; private set; }

        internal void Compose(Character character)
        {
            MoveComponent.Compose();
            MoveComponent.AppendCondition(new AtomicValue<bool>(!character.IsDead.Value));
            _root = MoveComponent.MoveRoot.Value;

            RotationComponent.Compose();
            RotationComponent.AppendCondition(new AtomicValue<bool>(!character.IsDead.Value));

            _targetPoint = character.transform;

            ConfigLookAtMechanics();
            ConfigFollowAtMechanics();
        }

        private void ConfigFollowAtMechanics()
        {
            var targetPosition = new AtomicFunction<Vector3>(() =>
            {
                return _targetPoint.position;
            });

            var rootPosition = new AtomicFunction<Vector3>(() =>
            {
                return _root.position;
            });

            var moveAction = new AtomicAction<Vector3>((Vector3 direction) =>
            {
                MoveComponent.MoveDirection.Value = new Vector3(direction.x, 0, direction.z);
            });

            _followToTargetMechanics = new FollowAtTargetMechanics(moveAction, targetPosition, rootPosition);

            _followToTargetMechanics.AppendCondition(new AtomicValue<bool>(_targetPoint != null));

            _followToTargetMechanics.AppendCondition(new AtomicFunction<bool>(CheckDistance()));
        }

        private Func<bool> CheckDistance()
        {
            return () =>
            {
                float distance = Vector3.Distance(_targetPoint.position, _root.position);

                return distance - _followDistance > 1;
            };
        }

        private void ConfigLookAtMechanics()
        {
            var targetPosition = new AtomicFunction<Vector3>(() =>
            {
                return _targetPoint.position;
            });

            var rootPosition = new AtomicFunction<Vector3>(() =>
            {
                return RotationComponent.RotationRoot.position;
            });

            _lookAtTargetMechanics = new FollowAtTargetMechanics(RotationComponent.RotateAction, targetPosition, rootPosition);

            _lookAtTargetMechanics.AppendCondition(new AtomicValue<bool>(_targetPoint != null));
        }

        internal void Update(float deltaTime)
        {
            _lookAtTargetMechanics.Update();
            _followToTargetMechanics.Update();
        }
    }
}