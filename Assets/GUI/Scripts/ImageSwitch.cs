using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageSwitch : MonoBehaviour {

    public Rigidbody2D target;
    public Texture active;
    public Texture inactive;
    
    public bool up;

    private RawImage img;

	// Use this for initialization
	void Start () {
        img = GetComponent<RawImage>();
	}
	
	// Update is called once per frame
	void Update () {
        if (up && target.velocity.y > 0 || !up && target.velocity.y < 0) img.texture = active;
        else img.texture = inactive;
	}
}
