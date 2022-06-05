using UnityEngine;

namespace Pooling_System
{
    public static class Pool
    {
        /// <summary>Get GameObject from pool</summary>
        public static GameObject Create(GameObject prefab, Vector3 pos, Transform parent = null)
        {
            return PoolController.Instance.CreateFromPool(prefab, pos, Quaternion.identity, parent);
        }
        
        /// <summary>Return GameObject to pool</summary>		
        public static void Return(GameObject createdObject)
        {
            PoolController.Instance.ReturnToPool(createdObject);
        }
    }
}