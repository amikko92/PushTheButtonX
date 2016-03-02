using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class VelocityText : MonoBehaviour {

    private Text txt;
    private DropPod pod;
    private GUIHandler guih;

	// Use this for initialization
	void Start () {
        txt = GetComponent<Text>();
        guih = transform.root.GetComponent<GUIHandler>();
        pod = guih.pod;
    }
	
	// Update is called once per frame
	void Update () {
        txt.text =  Convert.ToString(Mathf.Abs(Mathf.Round(pod.Velocity() * 18 / 5 * guih.multiplier  )) )  + "\nkm/h";
	}
}
