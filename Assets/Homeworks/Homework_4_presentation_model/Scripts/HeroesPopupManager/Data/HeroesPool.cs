using UnityEngine;

namespace PresentationModel
{
    [CreateAssetMenu(fileName = "HeroesPool", menuName = "Data/New HeroesPool")]
    public sealed class HeroesPool : ScriptableObject
    {
        public HeroInfo[] Heroes;
    }
}
