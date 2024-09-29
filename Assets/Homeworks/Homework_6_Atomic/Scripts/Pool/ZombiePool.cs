using UnityEngine;
using Zenject;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal class ZombiePool : MonoMemoryPool<Zombie>
    {
        private readonly Character _character;

        public ZombiePool(Character character)
        {
            _character = character;
        }

        protected override void Reinitialize(Zombie zombie)
        {
            zombie.Construct(_character);
        }

        
    }

    internal class BulletPool : MonoMemoryPool<Bullet>
    {
        
    }

}
