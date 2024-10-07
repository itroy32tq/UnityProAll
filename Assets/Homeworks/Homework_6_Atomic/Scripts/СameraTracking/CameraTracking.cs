using Atomic.Objects;
using UnityEngine;
using Zenject;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class CameraTracking : AtomicEntity
    {
        [SerializeField] private CameraTrackingCore _cameraTrackingCore;

        [Inject]
        private void Construct(Character character)
        {
            _cameraTrackingCore.Compose(character);
        }

        private void Update()
        {
            _cameraTrackingCore.Update(Time.deltaTime);
        }
    }
}
