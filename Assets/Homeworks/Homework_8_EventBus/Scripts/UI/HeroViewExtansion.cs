using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using UnityEngine;

namespace UI
{
    public static class HeroViewExtansion
    {
        public static UniTask DealDamageAnimationTask(this HeroView view, Action callback)
        {
            if (view == null) 
            {
                return UniTask.CompletedTask;
            }

            float _duration = 0.15f;

            UniTaskCompletionSource tcs = new();

            var annim = DOTween
                .Sequence()
                .Append(view.transform.DOScale(Vector3.one * 1.1f, _duration)
                .SetLoops(2, LoopType.Yoyo))
                .OnComplete(() => 
                {
                    tcs.TrySetResult();
                    callback.Invoke();
                });

             

            return tcs.Task;
        }

        
    }
}
