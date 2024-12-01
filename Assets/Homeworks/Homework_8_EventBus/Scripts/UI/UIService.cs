using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public sealed class UIService : MonoBehaviour
    {
        [SerializeField]
        private HeroListView bluePlayer;

        [SerializeField]
        private HeroListView redPlayer;

        public HeroListView GetBluePlayer()
        {
            return this.bluePlayer;
        }

        public HeroListView GetRedPlayer()
        {
            return this.redPlayer;
        }


    }

    public static class HeroListViewExtansion
    {
        public static IReadOnlyList<HeroView> GetHeroes(this HeroListView views)
        {
            return views.GetViews();
        }
    }
}