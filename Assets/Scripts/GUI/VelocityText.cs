using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class VelocityText : MonoBehaviour {

    private Text txt;
    private DropPod pod;

	// Use this for initialization
	void Start () {
        txt = GetComponent<Text>();
        pod = transform.root.GetComponent<GUIHandler>().pod;
    }
	
	// Update is called once per frame
	void Update () {
        txt.text = "Velocity\n" + Convert.ToString(Math.Abs(Math.Round(pod.Velocity(), 2))) + "\nm/s";
	}
}
