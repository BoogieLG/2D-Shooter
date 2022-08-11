using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    { 
        public BulletType bulletType;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<BulletType, Queue<GameObject>> poolDictionary;
    #region Singleton
    public static ObjectPooler instance { get; private set; }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion 
    private void Start()
    {
        poolDictionary = new Dictionary<BulletType, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject tempObj = Instantiate(pool.prefab);
                tempObj.transform.SetParent(transform);
                tempObj.SetActive(false);
                objectPool.Enqueue(tempObj);
            }

            poolDictionary.Add(pool.bulletType, objectPool);
        }
    }

    public GameObject SpawnFromPool(BulletType bulletType, Vector3 position, PlayerController playerController)
    {
        if (!poolDictionary.ContainsKey(bulletType))
        {
            Debug.LogError("Pool with tag " + bulletType + "doesn't exist");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[bulletType].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.GetComponent<BulletController>().SetStats(playerController);

        poolDictionary[bulletType].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}

