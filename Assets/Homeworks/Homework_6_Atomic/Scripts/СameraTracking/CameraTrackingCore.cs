using Atomic.Elements;
using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    [Serializable]
    internal sealed class CameraTrackingCore
    {
        private Transform _targetPoint;
        private FollowAtTargetMechanics _lookAtTargetMechanics;
        private FollowAtTargetMechanics _followToTargetMechanics;

        [SerializeField] private float _followDistance;

        [field: SerializeField] public MoveComponent MoveComponent { get; private set; }
        [field: SerializeField] public RotationComponent RotationComponent { get; private set; }

        internal void Compose(Character character)
        {
            MoveComponent.Compose();
            MoveComponent.AppendCondition(() => !character.IsDead.Value);
            RotationComponent.Compose();
            RotationComponent.AppendCondition(() => !character.IsDead.Value);

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
                return MoveComponent.MoveRoot.position;
            });

            var moveAction = new AtomicAction<Vector3>((Vector3 direction) =>
            {
                MoveComponent.MoveDirection.Value = direction;
            });

            _followToTargetMechanics = new FollowAtTargetMechanics(moveAction, targetPosition, rootPosition);
            _followToTargetMechanics.AppendCondition(() => _targetPoint != null);

            _followToTargetMechanics.AppendCondition(() => 
            {
                float distance = Vector3.Distance(_targetPoint.position, MoveComponent.MoveRoot.position);

                return distance > _followDistance;
            });
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

            _lookAtTargetMechanics.AppendCondition(() => _targetPoint != null);
        }

        internal void OnDisable()
        {
            
        }

        internal void Update(float deltaTime)
        {
            _lookAtTargetMechanics.Update();
            _followToTargetMechanics.Update();
            MoveComponent.Update(deltaTime);
        }
    }
}