using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string name;
        public int count;
        public GameObject prefebs;
    }

    public List<Pool> pools = new List<Pool>();
    public Dictionary<string, Queue<GameObject>> PoolDictionary;

    private void Awake()
    {
        PoolDictionary= new Dictionary<string, Queue<GameObject>>();

        foreach(var pool in pools)
        {
            Queue<GameObject> quueue = new Queue<GameObject>();
            for(int i=0; i<pool.count; i++)
            {
                GameObject obj = Instantiate(pool.prefebs);
                obj.SetActive(false);
                quueue.Enqueue(obj);
            }
            PoolDictionary.Add(pool.name, quueue);
        }
    }

    public GameObject SpawnFromPool(string name)
    {
        if (PoolDictionary.ContainsKey(name) == false)
        {
            return null;
        }

        GameObject obj = PoolDictionary[name].Dequeue();
        PoolDictionary[name].Enqueue(obj);

        return obj;
    }

    public void Get()
    {
        GameObject obj = SpawnFromPool(name);
        obj.SetActive(true);
    }
    public void Release(GameObject obj)
    {
        obj.SetActive(true);
    }
}
