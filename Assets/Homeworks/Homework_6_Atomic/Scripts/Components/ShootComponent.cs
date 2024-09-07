using Atomic.Elements;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    [Serializable]
    internal sealed class ShootComponent
    {
        public AtomicEvent ShootRequest;

        public AtomicEvent ShootAction;

        public AtomicEvent ShootEvent;

        public AtomicFunction<bool> CanFire;

        [SerializeField] private float _reloadTime;
        [SerializeField] private bool _isReloading;

        [SerializeField] private float _bulletsCraftTime;
        [SerializeField] private bool _canFire;


        [SerializeField] private Transform _firePoint;

        [ShowInInspector, ReadOnly] private float _reloadTimer;
        [ShowInInspector, ReadOnly] private float _bulletsCraftTimer;

        private readonly CompositeCondition _condition = new();

        private BulletSystem _bulletSystem;

        [SerializeField] private int _damage = 1;

        [SerializeField] private int _bulletsCapacity = 5;
        [ShowInInspector, ReadOnly]  private int _bulletsCount;


        public void Compose(BulletSystem bulletSystem)
        {
            ShootAction?.Subscribe(Shoot);
            CanFire.Compose(() => _canFire && !_isReloading && (_bulletsCount > 0));
            _bulletsCount = _bulletsCapacity;
            _bulletSystem = bulletSystem;

            _bulletsCraftTimer = _bulletsCraftTime;
        }


        public void Update(float deltaTime)
        {
            if (_isReloading)
            {
                _reloadTimer -= deltaTime;

                if (_reloadTimer <= 0)
                {
                    _isReloading = false;
                }
            }

            if (_bulletsCount < _bulletsCapacity)
            {
                _bulletsCraftTimer -= deltaTime;


                if (_bulletsCraftTimer <= 0)
                {
                    _bulletsCount++;
                    _bulletsCraftTimer = _bulletsCraftTime;
                }
            }

        }

        public void Shoot()
        {
            if (!CanFire.Value)
            {
                return;
            }

            if (_bulletsCount == 0)
            { 
            
            }

            BulletsArgs bulletsArgs = new(_firePoint.transform.position,
                                          _firePoint.transform.rotation,
                                          _firePoint.forward,
                                          _damage);

            _bulletSystem.Create(bulletsArgs);

            _bulletsCount--;

            _reloadTimer = _reloadTime;
            _isReloading = true;

            ShootEvent.Invoke();
            Debug.Log("Fire!");
        }

        public void AppendCondition(Func<bool> condition)
        {
            _condition.AddCondition(condition);
        }
    }
}
