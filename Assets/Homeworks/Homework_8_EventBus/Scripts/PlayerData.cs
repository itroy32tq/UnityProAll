using System;
using System.Collections.Generic;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class PlayerData
    {
        public PlayerName PlayerName { get; private set; }
        public List<Hero> Heroes { get; private set; } = new();
        public int CurrentHeroIndex { get; private set; } = -1;
        public int PreviusHeroIndex { get; private set; } = -1;
        public int CurrentTargetIndex { get; private set; } = -1;

        public PlayerData(PlayerName playerName, HeroInfo[] heroes)
        {
            PlayerName = playerName;

            foreach (var info in heroes)
            { 
                
                Hero hero = new(info);

                Heroes.Add(hero);
            }
        }

        public Hero GetCurrentHero()
        { 
            return Heroes[CurrentHeroIndex];
        }

        public Hero GetCurrentTarget()
        {
            return Heroes[CurrentTargetIndex];
        }

        public void SetCurrentIndex(int index)
        {

            CurrentHeroIndex = index;
        }

        public void SetPreviusIndex(int index)
        {
            PreviusHeroIndex = index;
        }

        public void SetTargetIndex(int index)
        {
            CurrentTargetIndex = index;
        }

        internal void SwitchToNextHero()
        {
            PreviusHeroIndex = CurrentHeroIndex;
            CurrentHeroIndex++;
        }

        internal void RemoveHero(int index)
        {
            Heroes.RemoveAt(index);
        }
    }
}
