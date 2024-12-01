using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    [RequireComponent(typeof(Canvas))]
    public sealed class HeroListView : MonoBehaviour
    {
        private const int FORWARD_LAYER = 10;
        private const int BACK_LAYER = 0;

        public event Action<HeroView> OnHeroClicked;

        private readonly Dictionary<HeroView, UnityAction> _viewActions = new();

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
                void action() => HandleHeroClicked(view);

                _viewActions[view] = action;

                view.OnClicked += action;
            }
        }

        private void HandleHeroClicked(HeroView view)
        {
            OnHeroClicked?.Invoke(view);
        }

        private void OnDisable()
        {
            foreach (var view in _views)
            {
                if (_viewActions.TryGetValue(view, out var action))
                {
                    view.OnClicked -= action;
                }
            }

            _viewActions.Clear();
        }

        public IReadOnlyList<HeroView> GetViews()
        {
            return _views;
        }

        public void RemoveView(int indexToRemove)
        {
            var view = _views[indexToRemove];

            if (_viewActions.TryGetValue(view, out var action))
            {
                view.OnClicked -= action;

                _viewActions.Remove(view);
            }

            view.gameObject.SetActive(false);

            _views = _views.Where((_, index) => index != indexToRemove).ToArray();
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