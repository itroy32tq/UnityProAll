using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(Canvas))]
    public sealed class HeroListView : MonoBehaviour
    {
        private const int FORWARD_LAYER = 10;
        private const int BACK_LAYER = 0;

        public event Action<HeroView> OnHeroClicked;

        [SerializeField]
        private HeroView[] _views;

        private Canvas _canvas;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
        }

        private void OnEnable()
        {
            foreach (var view in _views)
            {
                view.OnClicked += () => OnHeroClicked?.Invoke(view);
            }
        }

        private void OnDisable()
        {
            Action<HeroView> @event = OnHeroClicked;

            if (@event == null)
            {
                return;
            }

            foreach (var @delegate in @event.GetInvocationList())
            {
                OnHeroClicked -= (Action<HeroView>) @delegate;
            }
        }

        public IReadOnlyList<HeroView> GetViews()
        {
            return _views;
        }

        public HeroView GetView(int index)
        {
            return _views[index];
        }

        public void SetActive(bool isActive)
        {
            _canvas.sortingOrder = isActive ? FORWARD_LAYER : BACK_LAYER;
        }
    }
}