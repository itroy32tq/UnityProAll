using Zenject;

namespace Assets.Homeworks.Homework_6_Atomic
{
    internal class BulletPool : MonoMemoryPool<Bullet>
    {
        protected override void Reinitialize(Bullet bullet)
        {
            bullet.Construct();
        }
    }
}
