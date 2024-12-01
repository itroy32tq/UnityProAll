using UnityEditor;
using UnityEngine;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class RemoveHeroHandler : BaseHandler<RemoveHeroEvent>
    {
        private readonly GameContext _gameEngine;

        public RemoveHeroHandler(EventBus eventBus, GameContext gameEngine) : base(eventBus)
        {
            _gameEngine = gameEngine;
        }

        protected override void HandleEvent(RemoveHeroEvent evt)
        {
            
            PlayerPresenter[] presenters = { evt.GameEngine.PlayerPresenter, evt.GameEngine.OpponentPresenter };

            foreach (var playerPresenter in presenters)
            {
               
                playerPresenter.RemoveDeadHeroes();

                if (playerPresenter.Heroes.Count == 0)
                {
                    EditorApplication.isPaused = true;

                    Debug.Log(" игра окончена ");
                }
            }

        }
    }
}
