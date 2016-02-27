using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {

    // Singleton that is returned when instanciating the GameManager
    private static SpawnManager _instance = null;

    [SerializeField]
    private GameObject pod;

    [SerializeField]
    private GameObject[] spawnPoints;

    [SerializeField]
    private PoolDictionary poolDictionary;

    private SpawnManager() { }

    /*
        Initializes a dictionary based on the ObjectPools and Types
        Note that is important that Element N matches in the serialize 
        fields.

    */
    public void Awake()
    {
        GameObject go = GameObject.Find("PoolDictionary");
        Instance.poolDictionary = go.GetComponent<PoolDictionary>();
        int i = 0;
    }

    public static SpawnManager Instance
    {
        get
        {
            //_instance = GameObject.FindObjectOfType(typeof(GameManager)) as GameManager;

            if (_instance == null)
            {
                GameObject singleton = new GameObject();
                _instance = singleton.AddComponent<SpawnManager>();
                singleton.name = "(singleton) " + typeof(SpawnManager).ToString();
                
                
                DontDestroyOnLoad(singleton);

                Debug.Log("[Singleton] An instandce of "
                    + typeof(GameManager) + " is needed in the scene, so '"
                    + singleton + "'was created with DontDestroyOnLoad.");

            }
            else {
                Debug.Log("[Singleton] Using instance already created: " +
                _instance.gameObject.name);
            }

            return _instance;
        }
    }


    public GameObject GetObjectToSpawn(SpawnableType s)
    {
        Debug.Log(poolDictionary);
        GameObjectPool gop = poolDictionary.Get(s);
        

        return gop.GetPooledObject();
    }
}
