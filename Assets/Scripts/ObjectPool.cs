using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    private List<Obstacles> pooledObjects = new List<Obstacles>();
    private int amountToPool = 7;

    [SerializeField] private Obstacles[] Prefabs;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        //for (int i = 0; i < amountToPool; i++)
        //{
        //    GameObject obj = Instantiate(Prefabs[i]);
        //    obj.SetActive(false);
        //    pooledObjects.Add(obj);
        //}
    }

    public GameObject GetPooledObject(int index)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].gameObject.activeInHierarchy && index == pooledObjects[i].index)
            {
                return pooledObjects[i].gameObject;
            }
        }
        return createNewObject(index);
    }

    private GameObject createNewObject(int index)
    {
        Obstacles obj = Instantiate(Prefabs[index]);
        pooledObjects.Add(obj);
        return obj.gameObject;
    }
}
