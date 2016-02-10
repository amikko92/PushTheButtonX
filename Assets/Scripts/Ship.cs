using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour
{
    GameObject thrustFlame;

	// Use this for initialization
	void Start () {
	
	}

    void Awake()
    {
        thrustFlame = GameObject.Find("Thruster");
        thrustFlame.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey("space"))
        {
            thrustFlame.SetActive(true);
        }
        else 
        {
            thrustFlame.SetActive(false);
        }
	}
}
