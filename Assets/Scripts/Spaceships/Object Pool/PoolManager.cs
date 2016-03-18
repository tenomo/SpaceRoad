
namespace Spaceships.ObjectPool
{
    [System.Serializable]
    public class PoolManager : UnityEngine.MonoBehaviour , IPoolManager
    {
        [UnityEngine.SerializeField]
       private GameObjectPool roketPool;
        [UnityEngine.SerializeField]
        private GameObjectPool bulletPool;
        [UnityEngine.SerializeField]
        private GameObjectPool spaseShipPool;

        public   GameObjectPool RoketPool { get { return roketPool; }   }
        public GameObjectPool BulletPool { get { return bulletPool; } }
        public GameObjectPool SpaseShipPool { get { return spaseShipPool; } }
        
        
        //...//


        void Start()
        {
             
            roketPool.InitializePool();
            bulletPool.InitializePool();
            spaseShipPool.InitializePool();
        }
    }   

}

