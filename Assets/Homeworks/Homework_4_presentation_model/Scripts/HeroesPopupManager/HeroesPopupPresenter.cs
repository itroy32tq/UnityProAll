using System.Collections.Generic;

namespace PresentationModel
{
    public sealed class HeroesPopupPresenter : IHeroPopupPresenter
    {
        public IReadOnlyList<IHeroPresenter> HeroPresenters => _presenters;
        private readonly List<IHeroPresenter> _presenters = new();

        public HeroesPopupPresenter(HeroesPool heroesPool, HeroPresenterFactory factory)
        {
            HeroInfo[] heroes = heroesPool.Heroes;

            for (int i = 0, count = heroes.Length; i < count; i++)
            {
                HeroInfo hero = heroes[i];
                IHeroPresenter presenter = factory.Create(hero);
                _presenters.Add(presenter);
            }
        }
    }
}
