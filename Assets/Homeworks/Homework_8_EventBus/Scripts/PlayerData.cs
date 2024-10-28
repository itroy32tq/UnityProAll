namespace Assets.Homeworks.Homework_8_EventBus
{
    internal sealed class PlayerData
    {
        public PlayerName PlayerName { get; set; }
        public Hero[] Heroes { get; set; }
        public int CurrentHeroIndex { get; set; } = -1;
        public int PreviusHeroIndex { get; set; } = -1;
        public int CurrentTargetIndex { get; set; } = -1;

        public Hero GetCurrentHero()
        { 
            return Heroes[CurrentHeroIndex];
        }

    }
}
