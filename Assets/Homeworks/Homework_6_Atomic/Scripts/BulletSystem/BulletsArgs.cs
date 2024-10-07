using UnityEngine;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal struct BulletsArgs
    {
        public BulletsArgs(Vector3 position, Quaternion rotation, Vector3 direction, int damage)
        {
            Position = position;
            Rotation = rotation;
            Direction = direction;
            Damage = damage;
        }

        public Vector3 Position { get; private set; }
        public Vector3 Direction { get; private set; }
        public Quaternion Rotation { get; private set; }
        public int Damage { get; private set; }

       
    }
}
