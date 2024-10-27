using UI;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class DealDamageVisualTask : Task
    {
        private readonly HeroView _heroView;
        private readonly int _damage;

        public DealDamageVisualTask(HeroView heroView, int damage)
        {

            _heroView = heroView;
        }

        protected override void OnRun()
        {
            _heroView.DealDamageAnimationTask(Finish);

           // _heroView.SetStats();
        }
    }
}
