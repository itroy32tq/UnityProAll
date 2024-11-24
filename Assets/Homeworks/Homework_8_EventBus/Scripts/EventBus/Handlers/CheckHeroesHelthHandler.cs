

using UnityEngine;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class CheckHeroesHelthHandler : BaseHandler<CheckHeroesHelthEvent>
    {
        private readonly VisualPipeline _visualPipeline;
        private readonly EventBus _eventBus;

        public CheckHeroesHelthHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
            _eventBus = eventBus;
        }

        protected override void HandleEvent(CheckHeroesHelthEvent evt)
        {
            var presenters = evt.Engine.HeroesPresenters;

            foreach (var hero in presenters)
            {
                if (hero.IsDead())
                {
                    _visualPipeline.AddTask(new DestroyVisualTask(hero, _eventBus, evt.Engine));
                }
            }

        }
    }
}
