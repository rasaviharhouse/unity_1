using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public GameObject hazardPrefab;

    [SerializeField]
    public GameObject healthPackPrefab;

    [SerializeField]
    public GameObject player;

    public Transform[] spawnPoints;

    public float minSpawnInterval = 5f;
    public float maxSpawnInterval = 10f;

    public int minObjects = 2;
    public int maxObjects = 10;

    public float playerDetectionRadius = 2f;

    public int currentObjects = 0;

    public List<Transform> availableSpawnPoints;

    public List<GameObject> spawnedObjects = new List<GameObject>();

    public bool timerDone = false;


    void Start()
    {
        // Initialize the set of available spawn points.
        availableSpawnPoints.AddRange(spawnPoints);
    }

    void Update()
    {
        if (currentObjects < minObjects)
        {
            SpawnRandomObject();
        }
    }

    void SpawnRandomObject()
    {
        if (availableSpawnPoints.Count == 0 || player == null)
        {
            // No available spawn points, so we can't spawn anything right now.
            return;
        }

        int randomIndex = Random.Range(0, availableSpawnPoints.Count);

        Transform randomSpawnPoint = availableSpawnPoints[randomIndex];

        float distanceToPlayer = Vector3.Distance(randomSpawnPoint.position, player.transform.position);
        if (distanceToPlayer > playerDetectionRadius)
        {
            GameObject objectToSpawn = Random.Range(0f, 1f) > 0.5f ? hazardPrefab : healthPackPrefab;

            GameObject spawnedObject = Instantiate(objectToSpawn, randomSpawnPoint.position, Quaternion.identity);
            currentObjects++;

            // Remove the occupied spawn point from the available list.
            availableSpawnPoints.RemoveAt(randomIndex);

            // Add the spawned object to the list and attach a timer to it.
            spawnedObjects.Add(spawnedObject);

            timerDone = false;

            StartCoroutine(countdown(spawnedObject, randomSpawnPoint));
        }
    }

    private IEnumerator countdown(GameObject spawnedObject, Transform randomSpawnPoint)
    {
        while (!timerDone)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval)); //wait for 5-10 seconds
            destroyObject(spawnedObject, randomSpawnPoint);
            timerDone = true;
        }
        yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
        int num = Random.Range(0, maxObjects- currentObjects);
        while (num>0)
        {
            SpawnRandomObject();
            num--;
        }
    }

    public void destroyObject(GameObject spawnedObject, Transform spawnPoint)
    {
        try
        {   if(spawnedObject != null)
            {
                spawnedObjects.Remove(spawnedObject);
                Destroy(spawnedObject);
            } else
            {
                spawnedObjects.Remove(null);
            }
        }
        catch
        {
            Debug.LogError("The problem is with SpawnedObjects list removal or object destruction");
        }

        currentObjects--;

        // Add the destroyed spawn point back to the available list.
        availableSpawnPoints.Add(spawnPoint);
    }

}


