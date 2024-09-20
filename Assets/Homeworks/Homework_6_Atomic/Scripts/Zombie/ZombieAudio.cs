using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    [Serializable]
    internal class ZombieAudio
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _shootSfx;

        private ZombieCore _core;

        internal void Compose(ZombieCore zombieCore)
        {
            _core = zombieCore;
        }

        internal void OnDisable()
        {
            
        }

        internal void OnEnable()
        {
            
        }
    }
}