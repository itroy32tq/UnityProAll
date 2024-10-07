using Atomic.Elements;
using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    [Serializable]
    internal class ZombieCore
    {
        [field: SerializeField] public LifeComponent LifeComponent { get; internal set; }
        [field: SerializeField] public MoveComponent MoveComponent { get; internal set; }
        [field: SerializeField] public RotationComponent RotationComponent { get; private set; }
        [field: SerializeField] public ZombyAttackComponent ZombyAttackComponent { get; private set; }

        [SerializeField] private Collider _collider;
        [SerializeField] private float _followDistance;
        
        private Transform _targetPoint;
        private Transform _root;

        private FollowAtTargetMechanics _lookAtTargetMechanics;
        private FollowAtTargetMechanics _followToTargetMechanics;
        private SimpleMoveMechanics _simpleMoveMechanics;

        internal void Compose(Character character)
        {
            _targetPoint = character.transform;

            LifeComponent.Compose();

            MoveComponent.Compose();
            MoveComponent.AppendCondition(LifeComponent.IsAlive);

            _simpleMoveMechanics = new SimpleMoveMechanics(MoveComponent.MoveRoot,
                                                           MoveComponent.MoveDirection,
                                                           MoveComponent.MoveSpeed,
                                                           MoveComponent.CanMove);
            
            _root = MoveComponent.MoveRoot.Value;

            RotationComponent.Compose();
            RotationComponent.AppendCondition(LifeComponent.IsAlive);

            ZombyAttackComponent.Compose(_targetPoint.gameObject);
            ZombyAttackComponent.AppendCondition(LifeComponent.IsAlive);
            
            ConfigLookAtMechanics();
            ConfigFollowAtMechanics();

            LifeComponent.IsDead.Subscribe(isDead => _collider.enabled = !isDead);
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
                MoveComponent.MoveDirection.Value = direction;
            });

            _followToTargetMechanics = new FollowAtTargetMechanics(moveAction, targetPosition, rootPosition);

            _followToTargetMechanics.AppendCondition(new AtomicValue<bool>(_targetPoint != null));

            _followToTargetMechanics.AppendCondition(LifeComponent.IsAlive);

            _followToTargetMechanics.AppendCondition(new AtomicFunction<bool>(() =>
            {
                float distance = Vector3.Distance(_targetPoint.position, _root.position);

                return distance > _followDistance;
            }));
        }

        internal void OnDisable()
        {
            return;
        }

        internal void Update(float deltaTime)
        {
            ZombyAttackComponent.Update(deltaTime);

            _lookAtTargetMechanics.Update();
            _followToTargetMechanics.Update();
            _simpleMoveMechanics.Update(deltaTime);
        }
    }
}