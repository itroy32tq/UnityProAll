namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class DealDamageVisualTask : Task
    {
        private readonly float _duration;

        public DealDamageVisualTask(IEntity entity, float duration = 0.15f)
        {

            _duration = duration;
        }

        protected override void OnRun()
        {
            //_transform.Value.DOScale(Vector3.one * 1.1f, _duration).SetLoops(2, LoopType.Yoyo).OnComplete(Finish);
        }
    }
}
