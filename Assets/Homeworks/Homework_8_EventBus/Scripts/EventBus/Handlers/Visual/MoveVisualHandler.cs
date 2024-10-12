using JetBrains.Annotations;
using Lessons.Game.Turn.Visual.Tasks;
using UnityEngine;

namespace Assets.Homeworks.Homework_8_EventBus
{
    [UsedImplicitly]
    internal sealed class MoveVisualHandler : BaseHandler<MoveEvent>
    {
        private readonly VisualPipeline _visualPipeline;
        private readonly LevelMap _levelMap;
        
        public MoveVisualHandler(EventBus eventBus, VisualPipeline visualPipeline, LevelMap levelMap) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
            _levelMap = levelMap;
        }

        protected override void HandleEvent(MoveEvent evt)
        {
            _visualPipeline.AddTask(new MoveVisualTask(evt.Entity, new Vector3()));
        }
    }
}