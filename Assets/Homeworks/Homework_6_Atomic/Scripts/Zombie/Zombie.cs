﻿using Atomic.Elements;
using Atomic.Objects;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class Zombie : AtomicEntity
    {
        [SerializeField] private ZombieCore _zombieCore;
        [SerializeField] private ZombieAnimation _zombieAnimation;
        [SerializeField] private ZombieVfx _vfx;
        [SerializeField] private ZombieAudio _audio;

        [Get(LifeAPI.TAKE_DAMAGE_ACTION)]
        public IAtomicAction<int> TakeDamageAction => _zombieCore.LifeComponent.TakeDamageAction;

        [Get(MoveAPI.MOVE_DIRECTION)]
        public IAtomicVariable<Vector3> MoveDirection => _zombieCore.MoveComponent.MoveDirection;

        public Action<Zombie> OnEnemyDieingHandler = delegate { };

        
        public void Construct(Character character)
        {

            _zombieCore.Compose(character);
            _zombieAnimation.Compose(_zombieCore);
            _vfx.Compose(_zombieCore);
            _audio.Compose(_zombieCore);

            _zombieAnimation.OnEnable();
            _vfx.OnEnable();
            _audio.OnEnable();

            _zombieCore.LifeComponent.IsDead.Subscribe(OnDienig);

        }

        private void OnDienig(bool isDead)
        {
            if (isDead)
            {
                OnEnemyDieingHandler.Invoke(this);
            }
        }

        private void Update()
        {
            _zombieCore.Update(Time.deltaTime);
        }

        private void OnDisable()
        {
            _zombieCore.OnDisable();
            _zombieAnimation.OnDisable();
            _vfx.OnDisable();
            _audio.OnDisable();

        }

    }
}