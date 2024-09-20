using Zenject;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal class ZombieFactory : Factory<Zombie>
    {
        private readonly Character _character;

        public ZombieFactory(Character character)
        {
            _character = character;
        }

        public override Zombie Create()
        {
            var zombie = base.Create();

            zombie.Construct(_character);

            return zombie;
        }
    }

    
}
