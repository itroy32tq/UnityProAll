using Assets.Homeworks.Homework_8_EventBus;

namespace Lessons.Game.Turn.Visual.Tasks
{
    internal sealed class DestroyVisualTask : Task
    {
        private readonly float _duration;

        public DestroyVisualTask(IEntity entity, float duration = 0.15f)
        {

            _duration = duration;
        }
        
        protected override void OnRun()
        {
            //_transform.Value.DOScale(Vector3.zero, _duration).OnComplete(Finish);
        }
    }
}