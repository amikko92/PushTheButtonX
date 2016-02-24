using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FuelGauge : MonoBehaviour {
    
    private RectTransform img;
    private DropPod pod;
    private int speed = 30;

	// Use this for initialization
	void Start () {
        img = GetComponent<RectTransform>();
        pod = transform.root.GetComponent<GUIHandler>().pod;
    }
	
	// Update is called once per frame
	void Update () {
        img.transform.rotation = Quaternion.Euler(0, 0, pod.Fuel() * speed);
	}
}
