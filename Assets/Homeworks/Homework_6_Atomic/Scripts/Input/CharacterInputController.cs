using Zenject;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class CharacterInputController : ITickable
    {
        private readonly MoveInput _moveInput = new();
        private readonly ShootInput _shootInput = new();

        public CharacterInputController(Character character)
        {
            _shootInput.OnInputShootingHandler += character.ShootRequest.Invoke;

            _moveInput.OnInputMovingHandler += (direction) => 
            {
                character.MoveDirection.Value = direction;
            };
        }

        public void Tick()
        {
            _moveInput.Update();
            _shootInput.Update();
        }
    }
}
