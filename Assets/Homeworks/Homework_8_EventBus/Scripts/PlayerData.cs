using UnityEngine;

namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class PlayerData
    {
        public PlayerName PlayerName { get; private set; }
        public Hero[] Heroes { get; private set; }
        public int CurrentHeroIndex { get; private set; } = -1;
        public int PreviusHeroIndex { get; private set; } = -1;
        public int CurrentTargetIndex { get; private set; } = -1;

        public PlayerData(PlayerName playerName, Hero[] heroes)
        {
            PlayerName = playerName;
            Heroes = heroes;
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
            Debug.Log($" SetCurrentIndex - {index} ");

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
            Debug.Log($" SwitchToNextHero - {PreviusHeroIndex} ");

            PreviusHeroIndex = CurrentHeroIndex;
            CurrentHeroIndex++;
        }
    }
}
