using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

    [SerializeField]
    private SpawnPoint spawnPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spawnPoint.ActivateSpawn();
        }
    }
}
