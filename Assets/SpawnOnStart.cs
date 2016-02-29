using UnityEngine;
using System.Collections;

public class SpawnOnStart : MonoBehaviour
{

    [SerializeField]
    private bool continuousSpawning;

    [SerializeField]
    private SpawnManager spawnManager;

    [SerializeField]
    private int nbrToSpawn;

    [SerializeField]
    private float spawnDelayOffset;

    [SerializeField]
    private float spawnDelay;

    [SerializeField]
    private SpawnableType spawnType;

    private float time = 0;

    private GameObject spawn;

    private int nbrSpawned;

    void Awake()
    { 
        time = Time.time - spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {

        if (continuousSpawning && Time.time - time > spawnDelay)
        {
            PointSpawn();
        }

        else if (Time.time - time > spawnDelay && nbrSpawned < nbrToSpawn)
        {
            PointSpawn();
            nbrSpawned++;
        }
    }

    public void PointSpawn()
    {

        GameObject spawn = spawnManager.ManagerSpawn(spawnType);
        if (spawn != null)
        {
            spawn.transform.position = transform.position;
            spawn.SetActive(true);
            time = Time.time + Random.Range(-spawnDelayOffset, spawnDelayOffset);
        }
    }
}
