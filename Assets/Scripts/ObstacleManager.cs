using UnityEngine;
using System.Collections;

public class ObstacleManager : MonoBehaviour {

    //public PlayerAlive playerAlive;

    [SerializeField]
    private GameObjectPool[] objectPools;

    [SerializeField]
    private float spawnFrequency = 1.0f;

    [SerializeField]
    private GameObject pod;

    [SerializeField]
    private GameObject[] spawnPoints;

    private GameObjectPool AsteroidPool;

    // Use this for initialization
    void Start ()
    { 
	}
	
    public GameObject ManagerSpawn(SpawnableType s)
    {
        if (pod.transform.position.y > 2)
        {
            switch (s)
            {
                case SpawnableType.Asteroid:
                    foreach (GameObjectPool gop in objectPools)
                    {
                        if (gop.CompareTag("AsteroidPool"))
                        {
                            AsteroidPool = gop; 
                        }
                    }
                    GameObject asteroid = AsteroidPool.GetPooledObject();
                    if (asteroid != null)
                    {
                        return asteroid;
                    }
                    break;
            }
        }

        return null;
    }
}
