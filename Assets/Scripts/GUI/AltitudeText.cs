using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class AltitudeText : MonoBehaviour {
    
    private Text txt;
    private DropPod pod;

    // "Hack" to make sure that altitude is 0 when on the ground, should be easy to make it work relative to the pod
    private float offset = 0.5f;

    private GUIHandler guih;

    // Use this for initialization
    void Start () {
        txt = GetComponent<Text>();
        GameObject go = GameObject.Find("GUIManager");
        guih = transform.root.GetComponent<GUIHandler>();
        pod = guih.pod;
    }
	
	// Update is called once per frame
	void Update () {
        txt.text = "Altitude\n" + Convert.ToString(Math.Round(pod.Altitude() - offset) * guih.multiplier) + " m";
    }
}
