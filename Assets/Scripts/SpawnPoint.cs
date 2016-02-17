using UnityEngine;
using System.Collections;

public enum SpawnableType { Asteroid };

public class SpawnPoint : MonoBehaviour {

    [SerializeField]
    private ObstacleManager spawnManager;

    [SerializeField]
    private bool several;

    [SerializeField]
    private int nbrToSpawn;

    [SerializeField]
    private int spawnFrequency;

    [SerializeField]
    private float spawnDelay;

    [SerializeField]
    private SpawnableType spawnType;

    private float time = 0;

	
	// Update is called once per frame
	void Update () {
	
	}

    public void PointSpawn()
    {
        time = Time.deltaTime;

        if (several)
        {
            SpawnSeveral(nbrToSpawn);
        }

        else
        {
            GameObject spawn = spawnManager.ManagerSpawn(spawnType);

            spawn.transform.position = transform.position;
            spawn.SetActive(true);
        }        
    }

    void SpawnSeveral(int nbrToSpawn)
    {
        for (int i = 0; i < nbrToSpawn; i++)
        {
            GameObject spawn = spawnManager.ManagerSpawn(spawnType);

            spawn.transform.position = transform.position;
            spawn.SetActive(true);
        }

    }
}
