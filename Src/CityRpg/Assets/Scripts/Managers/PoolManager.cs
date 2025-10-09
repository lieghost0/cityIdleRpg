using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Entities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using static Managers.PoolManager;

namespace Managers
{
    public class PoolManager : MonoSingleton<PoolManager>
    {
        [System.Serializable]
        public class Pool
        {
            public string tag;
            public GameObject prefab;
            public int size;
            public Transform parent;
        }

        public List<Pool> pools;
        private Dictionary<string, Queue<GameObject>> poolDictionary;

        protected override void OnStart()
        {
            poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (Pool pool in pools)
            {
                Queue<GameObject> gameObjects = new Queue<GameObject>();

                Transform parent = pool.parent;
                if(parent == null)
                {
                    parent = new GameObject(pool.tag + "_pool").transform;
                }
                for (int i = 0; i < pool.size; i++)
                {
                    GameObject go = Instantiate(pool.prefab, parent);
                    go.SetActive(false);
                    gameObjects.Enqueue(go);
                }
                poolDictionary[pool.tag] = gameObjects;
            }
        }

        public GameObject SpawnOnPool(string tag)
        {
            Queue<GameObject> objectPool = null;
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.LogErrorFormat("Pool with tag {0} doesn't exist", tag);
                return null;
            }
            objectPool = poolDictionary[tag];

            if (objectPool.Count == 0)
            {
                Pool pool = this.GetPoolByTag(tag);
                GameObject go = Instantiate(pool.prefab);
                return SetupPooledObject(go);
            }

            GameObject obj = objectPool.Dequeue();
            return SetupPooledObject(obj);
        }

        private GameObject SetupPooledObject(GameObject obj)
        {
            obj.SetActive(true);

            IPoolable poolableObj = obj.GetComponent<IPoolable>();
            if (poolableObj != null)
            {
                poolableObj.OnObjectSpawn();
            }
            return obj;
        }

        public void ReturnToPool(string tag, GameObject obj)
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.LogErrorFormat("Pool with tag {0} doesn't exist", tag);
                return;
            }

            obj.SetActive(false);

            poolDictionary[tag].Enqueue(obj);
        }

        private Pool GetPoolByTag(string tag)
        {
            foreach (Pool pool in pools)
            {
                if(pool.tag == tag)
                {
                    return pool;
                }
            }
            return null;
        }
    }

    public interface IPoolable
    {
        void OnObjectSpawn();
    }
}
