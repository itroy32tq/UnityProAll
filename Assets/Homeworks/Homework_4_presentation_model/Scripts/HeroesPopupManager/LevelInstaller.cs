using UnityEngine;
using Zenject;


namespace PresentationModel
{
    public sealed class LevelInstaller : MonoInstaller
    {
        [SerializeField] private HeroesPopupManager _managerPref;
        [SerializeField] private HeroPopup _popupPref;

        public override void InstallBindings()
        {
            new HeroInstaller(Container);
            Container.Bind<HeroPopup>().FromInstance(_popupPref).AsSingle().NonLazy();
            Container.Bind<HeroesPopupManager>().FromInstance(_managerPref).AsSingle().NonLazy();
        }
    }
}
