using Cysharp.Threading.Tasks;
using UI;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class AttackVisualTask : Task
    {
        private readonly HeroView _current;
        private readonly HeroView _target;

        public AttackVisualTask(HeroView current, HeroView target)
        {
            _current = current;
            _target = target;
        }

        protected override void OnRun()
        {
            _current.AnimateAttack(_target)
                .ContinueWith(Finish)
                .Forget();
        }
       
    }
}