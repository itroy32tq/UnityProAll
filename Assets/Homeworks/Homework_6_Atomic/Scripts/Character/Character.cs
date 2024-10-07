using Atomic.Elements;
using Atomic.Objects;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using Zenject;


namespace Assets.Homeworks.Homework_6_Atomic
{
    internal sealed class Character : AtomicEntity
    {
        [Get(MoveAPI.MOVE_DIRECTION)]
        public IAtomicVariable<Vector3> MoveDirection => _characterCore.MoveComponent.MoveDirection;

        [Get(ShootAPI.SHOOT_REQUEST)]
        public IAtomicAction ShootRequest => _characterCore.ShootComponent.ShootRequest;

        [Get(LifeAPI.TAKE_DAMAGE_ACTION)]
        public IAtomicAction<int> TakeDamageAction => _characterCore.LifeComponent.TakeDamageAction;

        [Get(LifeAPI.IS_DEAD)]
        public IAtomicVariable<bool> IsDead => _characterCore.LifeComponent.IsDead;

        [SerializeField] private CharacterCore _characterCore;
        [SerializeField] private CharacterAnimation _characterAnimation;
        [SerializeField] private CharacterVfx _vfx;
        [SerializeField] private CharacterAudio _audio;

        [Inject]
        [SuppressMessage("CodeQuality", "IDE0051")]
        private void Construct(BulletSystem bulletSystem, MouseRotateInput mouseRotateInput) 
        {
            _characterCore.Compose(bulletSystem, mouseRotateInput);
            _characterAnimation.Compose(_characterCore);
            _vfx.Compose(_characterCore);
            _audio.Compose(_characterCore);

            _characterAnimation.OnEnable();
            _vfx.OnEnable();
            _audio.OnEnable();
        }

        private void Update()
        {
            _characterCore.Update(Time.deltaTime);
        }

        private void OnDisable()
        {
            _characterAnimation.OnDisable();
            _vfx.OnDisable();
            _audio.OnDisable();
        }

    }
}

