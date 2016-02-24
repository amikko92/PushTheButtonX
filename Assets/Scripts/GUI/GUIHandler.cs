using UnityEngine;
using System.Collections;

public class GUIHandler : MonoBehaviour {

    private DropPod m_pod;
    public DropPod pod
    {
        get { return m_pod; }
    }

	// Use this for initialization
	void Awake () {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        m_pod = go.GetComponent<DropPod>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
