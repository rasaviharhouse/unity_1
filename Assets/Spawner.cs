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
    public int maxObjects = 5;

    public float playerDetectionRadius = 1f;
    public float objectLifetime = 10f;

    public int currentObjects = 0;

    public List<Transform> availableSpawnPoints;

    public List<GameObject> spawnedObjects = new List<GameObject>();


    private bool timerDone = false;


    void Start()
    {
        // Initialize the set of available spawn points.
        availableSpawnPoints.AddRange(spawnPoints);
        //StartCoroutine(countdown());
    }

    void Update()
    {

        // Check and destroy objects that have exceeded their lifetime.
        //for (int i = spawnedObjects.Count - 1; i >= 0; i--)
        //{
        //    ObjectTimer timer = spawnedObjects[i].GetComponent<ObjectTimer>();
        //    if (timer != null && timer.TimerDone)
        //    {
        //        DestroyObject(i);
        //    }
        //}

        if (currentObjects < minObjects || (currentObjects >= minObjects && currentObjects < maxObjects && timerDone))
        {
            SpawnRandomObject();
        }
    }

    void SpawnRandomObject()
    {
        if (availableSpawnPoints.Count == 0)
        {
            // No available spawn points, so we can't spawn anything right now.
            return;
        }

        int randomIndex = Random.Range(0, availableSpawnPoints.Count);

        Transform randomSpawnPoint = availableSpawnPoints[randomIndex];

        //Debug.Log(randomSpawnPoint);

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
            //ObjectTimer timer = spawnedObject.AddComponent<ObjectTimer>();
            //timer.StartTimer(objectLifetime);
            if (timerDone)
            {
                StopCoroutine(countdown(spawnedObject, randomSpawnPoint));
            }
        }
    }

    void DestroyObject(int index)
    {
        Transform t = spawnedObjects[index].transform;
        // Add the destroyed spawn point back to the available list.
        Destroy(spawnedObjects[index]);
        spawnedObjects.RemoveAt(index);
        availableSpawnPoints.Add(t);
        currentObjects--;
    }

    private IEnumerator countdown(GameObject spawnedObject, Transform randomSpawnPoint)
    {
        while (!timerDone)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval)); //wait for 5-10 seconds
            //spawnedObjects.RemoveAt(index);
            Destroy(spawnedObject);
            spawnedObjects.Remove(spawnedObject);
            currentObjects--;

            // Add the destroyed spawn point back to the available list.
            availableSpawnPoints.Add(randomSpawnPoint);
            timerDone = true;
        }
    }

}


