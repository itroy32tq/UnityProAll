using Assets.Homeworks.Homework_8_EventBus;
using DG.Tweening;
using UnityEngine;

namespace Lessons.Game.Turn.Visual.Tasks
{
    internal sealed class AttackVisualTask : Task
    {
        private readonly Vector3 _position;
        private readonly float _duration;

        public AttackVisualTask(IEntity entity, Vector3 position, float duration = 0.15f)
        {
            _position = position;
            _duration = duration;
        }

        protected override void OnRun()
        {
            //_transform.Value.DOMove(_position, _duration).SetLoops(2, LoopType.Yoyo).OnComplete(Finish);
        }
    }
}