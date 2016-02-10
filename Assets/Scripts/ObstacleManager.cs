using UnityEngine;
using System.Collections;

public class ObstacleManager : MonoBehaviour {

    //public PlayerAlive playerAlive;
    [SerializeField]
    private GameObject obstacle;

    [SerializeField]
    private GameObject pod;

    [SerializeField]
    private float spawnTime = 1.0f;

    [SerializeField]
    private Transform[] spawnPoints;

    private GameObjectPool asteroidOP;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn",spawnTime, spawnTime);
        asteroidOP = GetComponent<GameObjectPool>();
	}
	
    void Spawn()
    {
        if (pod.transform.position.y > 2)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            GameObject spawnObject = asteroidOP.GetPooledObject();
            if (spawnObject != null)
            {
                spawnObject.transform.position = spawnPoints[spawnPointIndex].position;
                spawnObject.SetActive(true);
            }
        }
    }
}
