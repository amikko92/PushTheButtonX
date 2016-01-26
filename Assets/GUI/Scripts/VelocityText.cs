using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class VelocityText : MonoBehaviour {

    public Rigidbody target;

    private Text txt;

	// Use this for initialization
	void Start () {
        txt = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        txt.text = Convert.ToString(target.velocity.y);
	}
}
