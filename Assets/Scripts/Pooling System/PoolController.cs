using System.Collections.Generic;
using UnityEngine;

namespace Pooling_System
{
    /// <summary>
    /// GameObject/Component Pool.
    /// Allows to create and reuse GameObject/Components from prefab.
    /// Drag this controller on any GameObject.
    /// </summary>
    public class PoolController : MonoBehaviour
    {
        class Pool
        {
            public LinkedList<GameObject> InUse = new LinkedList<GameObject>();
            public LinkedList<GameObject> NoUse = new LinkedList<GameObject>();
        }
        
        public int DefaultCount = 20;
        
        private Dictionary<GameObject, Pool> prefabToPool = new Dictionary<GameObject, Pool>();
        private Dictionary<GameObject, Pool> objectToPool = new Dictionary<GameObject, Pool>();
        
        public static PoolController Instance { get => GetOrCreateInstance(); private set => instance = value; }
        
        private static PoolController instance;
        
        private static PoolController GetOrCreateInstance()
        {
            if (instance == null)
            {
                Debug.LogWarning($"{nameof(PoolController)} is not found on Scene. It will be created automatically.");
                var go = new GameObject { name = nameof(PoolController) };
                instance = go.AddComponent<PoolController>();
            }

            return instance;
        }
        
        void Awake()
        {
            if (instance == null)
                Instance = this;
        }
        
        private GameObject CreateFromPoolInternal(GameObject prefab, Transform holder)
        {
            if (!prefab)
                return null;

            var pool = GetOrCreatePool(prefab, DefaultCount);

            GameObject item = null;
            while (pool.NoUse.Count > 0)
            {
                item = pool.NoUse.Last.Value;
                pool.NoUse.RemoveLast();
                if (!item)//destroyed?
                {
                    continue;
                }
                pool.InUse.AddLast(item);
                item.SetActive(true);

                return item;
            }

            //no items in pool => create new
            item = Instantiate(prefab, holder ?? transform);
            pool.InUse.AddLast(item);
            objectToPool[item] = pool;

            return item;
        }
        
        /// <summary>Get GameObject from pool</summary>
        public GameObject CreateFromPool(GameObject prefab, Vector3 pos, Quaternion rotation, Transform parent = null)
        {
            var obj = CreateFromPoolInternal(prefab.gameObject, parent);
            if (parent != null)
                obj.transform.SetParent(parent, false);
            obj.transform.position = pos;
            obj.transform.rotation = rotation;
            return obj;
        }
        
        private Pool GetOrCreatePool(GameObject prefab, int count)
        {
            if (prefabToPool.TryGetValue(prefab, out var pool))
                return pool;

            prefabToPool[prefab] = pool = new Pool();

            for (int i = 0; i < count; i++)
            {
                var obj = Instantiate(prefab, transform);
                obj.SetActive(false);
                pool.NoUse.AddLast(obj);
                objectToPool[obj] = pool;
            }

            return pool;
        }

        /// <summary>Return GameObject to pool</summary>
        public void ReturnToPool(GameObject obj)
        {
            if (obj == null)
                return;

            if (!objectToPool.TryGetValue(obj, out var pool))
            {
                //Destroy(obj);
                return;
            }

            obj.transform.SetParent(this.transform, false);
            obj.SetActive(false);
            if (pool.InUse.Remove(obj))
            {
                pool.NoUse.AddLast(obj);
            }
        }
    }
}
