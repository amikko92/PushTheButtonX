using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageSwitch : MonoBehaviour {
    
    public Texture active;
    public Texture inactive;
    
    public bool up;

    private RawImage img;
    private DropPod pod;

	// Use this for initialization
	void Start () {
        img = GetComponent<RawImage>();
        pod = transform.root.GetComponent<GUIHandler>().pod;
    }
	
	// Update is called once per frame
	void Update () {
        if (up && pod.Velocity() > 0 || !up && pod.Velocity() < 0) img.texture = active;
        else img.texture = inactive;
	}
}
