using UnityEngine;
using System.Collections;

public class orbRotation : MonoBehaviour {

    Transform m_translation;

    [SerializeField]
    private float speed;

	// Use this for initialization
	void Start () {
        m_translation = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 rotation = new Vector3(Time.deltaTime * speed, Time.deltaTime * speed, Time.deltaTime * speed);
        m_translation.Rotate(rotation);
	}
}