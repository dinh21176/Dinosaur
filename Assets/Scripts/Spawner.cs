using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject
    {
        
        public GameObject prefab;
        [Range(0f,1f)]
        public float spawnChance;

    }

    public SpawnableObject[] objects;
    public float minSpawnRate = 0.5f;
    public float maxSpawnRate = 1.5f;

    private void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }
    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Spawn()
    {
        //float spawnChance = Random.value;
        int rand = Random.Range(0, 700) % 7;
        GameObject obstacles = ObjectPool.instance.GetPooledObject(rand);
        obstacles.SetActive(true);
        obstacles.transform.position = Vector3.right + transform.position;
        //foreach (var obj in objects)
        //{

        //    if (obstacles != null)
        //    {
        //        obstacles.SetActive(true);
        //        obstacles.transform.position += transform.position;
        //    }
        //    spawnChance -= obj.spawnChance;
        //}
        Invoke(nameof(Spawn), 0.6f);
        //Invoke(nameof(Spawn), 0.2f);
    }
}

