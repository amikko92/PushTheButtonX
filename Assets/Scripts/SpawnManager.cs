using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    //public PlayerAlive playerAlive;

    [SerializeField]
    private GameObjectPool[] objectPools;

    [SerializeField]
    private GameObject pod;

    [SerializeField]
    private GameObject[] spawnPoints;

    private GameObjectPool SpawnPool;

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
                            SpawnPool = gop; 
                        }
                    }
                    GameObject asteroid = SpawnPool.GetPooledObject();
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
