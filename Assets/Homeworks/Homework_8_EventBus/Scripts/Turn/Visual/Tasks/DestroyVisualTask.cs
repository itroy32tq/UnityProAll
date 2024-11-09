using Assets.Homeworks.Homework_8_EventBus;

namespace Lessons.Game.Turn.Visual.Tasks
{
    internal sealed class DestroyVisualTask : Task
    {
        private readonly float _duration;
        private readonly Hero _hero;

        public DestroyVisualTask(Hero hero)
        {
            _hero = hero;
        }
        
        protected override void OnRun()
        {
            //_transform.Value.DOScale(Vector3.zero, _duration).OnComplete(Finish);
        }
    }
}