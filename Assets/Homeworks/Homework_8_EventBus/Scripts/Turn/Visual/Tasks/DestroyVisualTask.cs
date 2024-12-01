using System;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class DestroyVisualTask : Task
    {
        private readonly EventBus _eventBus;
        private readonly GameContext _engine;

        public DestroyVisualTask(HeroPresenter hero, EventBus eventBus, GameContext gameEngine)
        {
            Hero = hero;
            _eventBus = eventBus;
            _engine = gameEngine;
        }

        public HeroPresenter Hero { get; }

        protected override void OnRun()
        {
            Hero.DestroyVisualTask(RemoveHeroesAction);
        }

        private void RemoveHeroesAction()
        {
            _engine.CheckPlayerData();

            Finish();
        }
    }
}