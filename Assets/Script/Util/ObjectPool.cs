using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> PoolDictionary;
    private Camera mainCamera;

    private void Awake()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
        mainCamera = Camera.main;
        foreach (var pool in pools)
        {
            Queue<GameObject> queue = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab, transform);
                obj.SetActive(false);
                queue.Enqueue(obj);
            }

            PoolDictionary.Add(pool.tag, queue);
        }
    }

    public GameObject SpawnFromPool(string tag)
    {
        if(!PoolDictionary.ContainsKey(tag))
        {
            return null;
        }

        GameObject obj = PoolDictionary[tag].Dequeue();
        PoolDictionary[tag].Enqueue(obj);

        obj.SetActive(true);
        return obj;
    }

    public GameObject SpawnFromPoolMonster(string tag)
    {
        if (!PoolDictionary.ContainsKey(tag))
        {
            return null;
        }

        GameObject obj = PoolDictionary[tag].Dequeue();
        PoolDictionary[tag].Enqueue(obj);
        // obj.transform.position = GetRandomScreenPosition();
        obj.SetActive(true);
        return obj;
    }

    Vector2 GetRandomScreenPosition()
    {
        float height = mainCamera.orthographicSize * 2f; // 카메라 높이 (위 아래 총 길이)
        float width = height * mainCamera.aspect; // 카메라 너비 (좌우 총 길이)

        float randomX = Random.Range(mainCamera.transform.position.x - width / 2, mainCamera.transform.position.x + width / 2);
        float randomY = Random.Range(mainCamera.transform.position.y - height / 2, mainCamera.transform.position.y + height / 2);

        return new Vector2(randomX, randomY);
    }
}
