using Assets.Homeworks.Homework_8_EventBus;

namespace Lessons.Game.Turn.Visual.Tasks
{
    internal sealed class DestroyVisualTask : Task
    {
        public DestroyVisualTask(HeroPresenter hero)
        {
            Hero = hero;
        }

        public HeroPresenter Hero { get; }

        protected override void OnRun()
        {
            Hero.DestroyVisualTask(Finish);
        }
    }
}