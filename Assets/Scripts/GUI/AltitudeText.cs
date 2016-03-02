using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class AltitudeText : MonoBehaviour {
    
    private Text txt;
    private DropPod pod;
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
        // clamp negative values to 0
        int value = (int) Math.Round(pod.Altitude()) * guih.multiplier;
        if (value < 0) value = 0;

        txt.text = "Altitude\n" + Convert.ToString(value) + " m";
    }
}
