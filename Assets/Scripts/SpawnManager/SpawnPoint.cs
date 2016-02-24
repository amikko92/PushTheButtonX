using UnityEngine;
using System.Collections;

public enum SpawnableType { Asteroid, Laser};

public class SpawnPoint : MonoBehaviour {

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

    private bool triggered;

    private int nbrSpawned;


    public void ActivateSpawn()
    {
        triggered = true;
        time = Time.time;
    }

    // Update is called once per frame
    void Update () {

        if (continuousSpawning && Time.time - time > spawnDelay)
        {
            PointSpawn();
        }

        else if (triggered && Time.time - time > spawnDelay && nbrSpawned < nbrToSpawn)
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
