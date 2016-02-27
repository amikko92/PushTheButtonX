using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PoolDictionary : MonoBehaviour {

    [SerializeField]
    private SpawnableType[] types;

    [SerializeField]
    private GameObjectPool[] objectPools;

    public Dictionary<SpawnableType, GameObjectPool> PD = new Dictionary<SpawnableType, GameObjectPool>();

    // Use this for initialization
    void Awake () {
        for (int i = 0; i < objectPools.Length; i++)
        {
            PD.Add(types[i], objectPools[i]);
        }
    }

    public GameObjectPool Get(SpawnableType s)
    {
        return PD[s];
    }    
	
	// Update is called once per frame
	void Update () {
	
	}
}
