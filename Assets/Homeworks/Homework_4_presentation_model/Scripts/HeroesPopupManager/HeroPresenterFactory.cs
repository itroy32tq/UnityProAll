namespace PresentationModel
{
    public sealed class HeroPresenterFactory
    {     
        public IHeroPresenter Create(HeroInfo heroInfo)
        {
            return new HeroPresenter(heroInfo);
        }
    }
}
