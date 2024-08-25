using System;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    [Serializable]
    internal sealed class CharacterAudio
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _shootSfx;

        private CharacterCore _core;

        public void Compose(CharacterCore core)
        {
            _core = core;
        }

        public void OnEnable()
        {
            _core.ShootComponent.ShootEvent.Subscribe(OnShoot);
        }

        public void OnDisable()
        {
            _core.ShootComponent.ShootEvent.Unsubscribe(OnShoot);
        }

        private void OnShoot()
        {
            _audioSource.clip = _shootSfx;
            _audioSource.Play();
        }
    }
}
