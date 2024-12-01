using Cysharp.Threading.Tasks;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class DealDamageVisualTask : Task
    {
        public HeroPresenter HeroPresenter { get; }
        public int Value { get; }

        public DealDamageVisualTask(HeroPresenter presenter, int value)
        {
            HeroPresenter = presenter;

            Value = value;
        }


        protected override void OnRun()
        {
           
            RunAnimation().Forget();

        }

        private async UniTask RunAnimation()
        {
            await HeroPresenter.DealDamageAnimationTask();

            HeroPresenter.TakeDamage(Value);

            Finish();
        }

    }
}
