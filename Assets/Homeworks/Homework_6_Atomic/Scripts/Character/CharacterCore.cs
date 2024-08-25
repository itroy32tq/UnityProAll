using Atomic.Elements;
using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    [Serializable]
    internal sealed class CharacterCore
    {
        public MoveComponent MoveComponent;
        public LifeComponent LifeComponent;
        public RotationComponent RotationComponent;
        public ShootComponent ShootComponent;

        [SerializeField, HideInInspector] private MoveInput _moveInput;
        [SerializeField, HideInInspector] private ShootInput _shootInput;

        [SerializeField] private Collider _collider;
        [SerializeField] private Transform _targetPoint;

        private LookAtTargetMechanics _lookAtTargetMechanics;

        public void Compose()
        {
            _moveInput.OnInputMovingHandler += Move;
            _shootInput.OnInputShootingHandler += Shoot;

            MoveComponent.Compose();
            MoveComponent.AppendCondition(LifeComponent.IsAlive);
            // MoveComponent.AppendCondition(ShootComponent.CanFire.Invoke);

            RotationComponent.Construct();
            RotationComponent.AppendCondition(LifeComponent.IsAlive);

            ShootComponent.Construct();

            var targetPosition = new AtomicFunction<Vector3>(() =>
            {
                return _targetPoint.position;
            });

            var rootPosition = new AtomicFunction<Vector3>(() =>
            {
                return RotationComponent.RotationRoot.position;
            });

            var hasTarget = new AtomicFunction<bool>(() =>
            {
                return _targetPoint != null;
            });

            _lookAtTargetMechanics =
                new LookAtTargetMechanics(RotationComponent.RotateAction, targetPosition,
                    rootPosition, hasTarget);

            LifeComponent.IsDead.Subscribe(isDead => _collider.enabled = !isDead);
        }

        private void Shoot()
        {
            ShootComponent.ShootRequest.Invoke();
        }

        private void Move(Vector3 direction)
        {
            MoveComponent.MoveDirection.Value = direction;
        }

        public void Update(float deltaTime)
        {
            _moveInput.Update();
            _shootInput.Update();


            MoveComponent.Update(deltaTime);
            ShootComponent.Update(deltaTime);

            _lookAtTargetMechanics.Update();
        }

        internal void OnDisable()
        {
            _moveInput.OnInputMovingHandler -= Move;
            _shootInput.OnInputShootingHandler -= Shoot;
        }
    }
}
