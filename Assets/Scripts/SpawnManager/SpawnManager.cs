using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {

    [SerializeField]
    private GameObjectPool[] objectPools;

    [SerializeField]
    private SpawnableType[] types;

    public Dictionary<SpawnableType, GameObjectPool> _objectPools;

    [SerializeField]
    private GameObject pod;

    [SerializeField]
    private GameObject[] spawnPoints;

    /*
        Initializes a dictionary based on the ObjectPools and Types
        Note that is important that Element N matches in the serialize 
        fields.

    */
    public void Start()
    {
        _objectPools = new Dictionary<SpawnableType, GameObjectPool>();

        for (int i = 0; i < objectPools.Length; i++)
        {
            _objectPools.Add(types[i], objectPools[i]);
        }
    }

	
    public GameObject ManagerSpawn(SpawnableType s)
    {
        // TODO: Is this to make sure that the player has not yet landed
        // what if player lands on a different altitude?
        if (pod.transform.position.y > 2)
        {
            return _objectPools[s].GetPooledObject();
        }

        return null;
    }
}
