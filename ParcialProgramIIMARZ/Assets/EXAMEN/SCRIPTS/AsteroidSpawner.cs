using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public float minimumSpawnTime;
    public float maximumSpawnTime;
    public GameObject prefab;
    public Transform player;

    private void Start()
    {
        spawnPoints = GetComponentsInChildren<Transform>();

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            int spawn = RandomSpawn();
            Transform spawnPoint = spawnPoints[spawn];

            GameObject asteroid = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);

            AsteroideMov asteroidMovement = asteroid.GetComponent<AsteroideMov>();
            if (asteroidMovement != null)
            {
                asteroidMovement.SetPlayer(player);
            }

            yield return new WaitForSeconds(SpawnTime());
        }
    }
    private int RandomSpawn()
    {
        return Random.Range(0, spawnPoints.Length);
    }

    private float SpawnTime()
    {
        return Random.Range(minimumSpawnTime, maximumSpawnTime);
    }
    
}
