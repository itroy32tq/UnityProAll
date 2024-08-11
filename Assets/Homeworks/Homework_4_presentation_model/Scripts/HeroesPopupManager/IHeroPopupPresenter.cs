using System.Collections.Generic;

namespace PresentationModel
{
    public interface IHeroPopupPresenter : IPresenter
    {
        IReadOnlyList<IHeroPresenter> HeroPresenters { get; }
    }
}
