using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class CharacterAudio
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _shootSfx;

        private CharacterCore _core;
    }
}
