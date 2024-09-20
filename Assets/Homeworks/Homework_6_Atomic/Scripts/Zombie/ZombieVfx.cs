using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    [Serializable]
    internal class ZombieVfx
    {
        [SerializeField] private ParticleSystem _takeDamageVfx;

        private ZombieCore _zombieCore;

        internal void Compose(ZombieCore zombieCore)
        {
            _zombieCore = zombieCore;
        }

        internal void OnDisable()
        {
            
            _zombieCore?.LifeComponent.TakeDamageEvent?.Unsubscribe(OnTakeDamage);
        }

        internal void OnEnable()
        {
            _zombieCore.LifeComponent.TakeDamageEvent.Subscribe(OnTakeDamage);
        }

        private void OnTakeDamage(int damage)
        {
            //Обработка с учетом урона
            _takeDamageVfx.Play();
        }
    }
}