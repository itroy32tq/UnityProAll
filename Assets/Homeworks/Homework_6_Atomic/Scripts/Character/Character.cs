using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;


namespace Assets.Homeworks.Homework_6_Atomic
{
    public class MoveAPI
    {
        public const string MOVE_DIRECTION = nameof(MOVE_DIRECTION);
    }

    public class ShootAPI
    {
        public const string SHOOT_REQUEST = nameof(SHOOT_REQUEST);
    }

    public class LifeAPI
    {
        public const string TAKE_DAMAGE_ACTION = nameof(TAKE_DAMAGE_ACTION);
    }

    internal sealed class Character : AtomicEntity
    {
        [Get(MoveAPI.MOVE_DIRECTION)]
        public IAtomicVariable<Vector3> MoveDirection => _characterCore.MoveComponent.MoveDirection;

        [Get(ShootAPI.SHOOT_REQUEST)]
        public IAtomicAction ShootRequest => _characterCore.ShootComponent.ShootRequest;

        [Get(LifeAPI.TAKE_DAMAGE_ACTION)]
        public IAtomicAction<int> TakeDamageAction => _characterCore.LifeComponent.TakeDamageAction;

        [SerializeField] private CharacterCore _characterCore;

        [SerializeField] private CharacterAnimation _characterAnimation;
        [SerializeField] private CharacterVfx _vfx;
        [SerializeField] private CharacterAudio _audio;
    }
}
