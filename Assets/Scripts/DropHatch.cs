using UnityEngine;
using System.Collections;

public class DropHatch : MonoBehaviour 
{
	private void Awake() 
	{
	
	}
	
	private void Update() 
	{
        if (Input.GetKeyDown(KeyCode.Space))
            Destroy(gameObject);
	}
}
