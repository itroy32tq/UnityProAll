using Cysharp.Threading.Tasks;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class AttackVisualTask : Task
    {
        private readonly GameContext _engine;

        public AttackVisualTask(GameContext gameEngine)
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