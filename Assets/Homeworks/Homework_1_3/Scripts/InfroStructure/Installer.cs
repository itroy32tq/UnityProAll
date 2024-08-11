using UnityEngine;

namespace InfroStructure
{
    public abstract class Installer : MonoBehaviour
    {
        public abstract void Install(DiContainer container);
    }
}
