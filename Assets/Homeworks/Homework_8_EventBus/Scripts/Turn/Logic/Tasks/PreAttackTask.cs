﻿

using UnityEngine;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class PreAttackTask : Task
    {
        private readonly GameEngine _gameEngine;
        private readonly VisualPipeline _visualPipeline;
        private readonly TurnPipeline _turnPipeline;
        private readonly EventBus _eventBus;
        private readonly GameState _gameState = GameState.preAttackState;

        public PreAttackTask(GameEngine gameEngine, VisualPipeline visualPipeline, TurnPipeline turnPipeline, EventBus eventBus)
        {
            _gameEngine = gameEngine;
            _visualPipeline = visualPipeline;
            _turnPipeline = turnPipeline;
            _eventBus = eventBus;
        }

        protected override void OnRun()
        {
            _visualPipeline.OnFinished += OnAnimationFinished;

            _eventBus.RaiseEvent(new SwithStateEvent(_gameState));
        }

        private void OnAnimationFinished()
        {
            Debug.Log("развилка на анимацию атаки");

            if (_gameEngine.HasValidTarget())
            {
                Debug.Log("идем за атакой ");

                _turnPipeline.AddTaskOfType<AttackTask>();
            }
            else 
            {
                _turnPipeline.AddTaskOfType<СhoiceOpponentHeroTask>();
            }

            Finish();
        }

        protected override void OnFinish()
        {
            _visualPipeline.OnFinished -= OnAnimationFinished;
        }
    }
}