using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FuelGauge : MonoBehaviour {

    public Rigidbody2D target;

    private RectTransform img;

    private int speed = 30;

	// Use this for initialization
	void Start () {
        img = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        img.transform.rotation = Quaternion.Euler(0, 0, target.position.y * speed);
	}
}
