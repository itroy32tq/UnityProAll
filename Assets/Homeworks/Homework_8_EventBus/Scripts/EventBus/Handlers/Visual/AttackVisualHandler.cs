namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class AttackVisualHandler : BaseHandler<AttackEvent>
    {
        private readonly VisualPipeline _visualPipeline;
        
        public AttackVisualHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(AttackEvent evt)
        {
           
            
            //_visualPipeline.AddTask(new AttackVisualTask(evt.Entity, new Vector3()));
        }
    }
}