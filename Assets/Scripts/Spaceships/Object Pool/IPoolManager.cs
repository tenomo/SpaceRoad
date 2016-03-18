namespace Spaceships.ObjectPool
{
    internal interface IPoolManager
    {
         GameObjectPool RoketPool { get; }
     GameObjectPool BulletPool { get; }
  GameObjectPool SpaseShipPool { get; }
    }
}