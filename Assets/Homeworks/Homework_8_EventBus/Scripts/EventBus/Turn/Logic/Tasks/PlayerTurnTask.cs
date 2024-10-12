using Lessons.Game.Services;
using UnityEngine;
using Zenject;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class PlayerTurnTask : Task
    {
        private readonly EventBus _eventBus;
        private readonly IEntity _player;
        
        [Inject]
        public PlayerTurnTask(EventBus eventBus, PlayerService playerService)
        {
            _eventBus = eventBus;
            _player = playerService.Player;
        }
        
        protected override void OnRun()
        {
            //_input.OnMove += OnMovePreformed;
        }

        protected override void OnFinish()
        {
            //_input.OnMove -= OnMovePreformed;
        }

        private void OnMovePreformed(Vector2Int direction)
        {
            _eventBus.RaiseEvent(new ApplyDirectionEvent(_player, direction));

            Finish();
        }
    }
}