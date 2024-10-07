using Atomic.Elements;
using Atomic.Objects;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    [Serializable]
    internal sealed class ZombyAttackComponent
    {
        [ShowInInspector, ReadOnly] private float _reloadTimer;
        [SerializeField] private float _reloadTime;
        [SerializeField] private int _damage = 1;
        [SerializeField] Transform _root;
        [SerializeField] private float _attackDistance;

        private readonly AtomicAnd _canAttack = new();
        private GameObject _target;

        public AtomicEvent ZombyAttackRequest;
        public AtomicEvent<int> ZombyAttackEvent;

        public void Compose(GameObject target)
        {
            _target = target;
            _reloadTimer = _reloadTime;

            _canAttack.Append(new AtomicFunction<bool>(() =>
            {
                float distance = Vector3.Distance(target.transform.position, _root.position);

                return distance < _attackDistance;
            }));
        }

        public void Update(float deltaTime)
        {
            
            if (!_canAttack.Invoke())
            {
                return;
            }

            _reloadTimer -= deltaTime;

            if (_reloadTimer <= 0)
            {
                _reloadTimer = _reloadTime;
                TryTakeDamage();
            }
        }

        private void TryTakeDamage()
        {
            if (_canAttack.Invoke())
            {
                if (_target.TryGetComponent(out IAtomicEntity atomicEntity))
                {
                    if (atomicEntity.TryGet<IAtomicAction<int>>(LifeAPI.TAKE_DAMAGE_ACTION, out var action))
                    {
                        action.Invoke(_damage);
                    }
                }
            }

            ZombyAttackEvent.Invoke(_damage);
        }

        public void AppendCondition(IAtomicValue<bool> condition)
        {
            _canAttack.Append(condition);
        }
    }
}
