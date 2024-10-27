using Cysharp.Threading.Tasks;
using UI;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class AttackVisualTask : Task
    {
        private readonly GameEngine _engine;

        public AttackVisualTask(GameEngine gameEngine)
        {
            _engine = gameEngine;
        }

        protected override void OnRun()
        {
            _engine.RunAnimationAttack()
                .ContinueWith(Finish)
                .Forget();
        }
       
    }
}