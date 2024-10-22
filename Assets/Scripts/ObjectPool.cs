using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string name;
        public int size;
        public GameObject prefebs;
    }

    public int poolSize = 300;
    public List<Pool> pools = new List<Pool>();
    public Dictionary<string, Queue<GameObject>> PoolDictionary;


    private void Start()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var pool in pools)
        {
            Queue<GameObject> quueue = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefebs);
                obj.SetActive(false); //미리 생성 후 비활성 화
                quueue.Enqueue(obj);
            }
            PoolDictionary.Add(pool.name, quueue);
        }
    }
       
    public GameObject SpawnFromPool(string name)
    {
        if (PoolDictionary.ContainsKey(name) == false)
        {
            Debug.Log("Not valid name");
            return null;
        }

        GameObject obj = PoolDictionary[name].Dequeue();
        PoolDictionary[name].Enqueue(obj);

        return obj;
    }

    public GameObject Get()
    {
        GameObject obj = SpawnFromPool(name);
        obj.SetActive(true);
        return obj;
    }
    public void Release(GameObject obj)
    {
        obj.SetActive(false);
    }
}
