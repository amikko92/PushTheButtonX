using UnityEngine;
using System.Collections;

public class ParticleCollider : MonoBehaviour {

    public LayerMask fireLayer;
    public Material aliveMTRL, destroyMTRL;

    private ParticleSystem ps;
    private Renderer renderer;
    private IEnumerator coroutine;

    private Collider2D collider2D;

	// Use this for initialization
	void Awake () {
        ps = GetComponent<ParticleSystem>();
        renderer = GetComponent<Renderer>();
        renderer.material = aliveMTRL;
        collider2D = GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnTriggerStay2D (Collider2D col)
    {
        string objLayerName = LayerMask.LayerToName(col.gameObject.layer);
        if (string.Equals(objLayerName, "Player"))
        {
            var pod = col.GetComponent<DropPod>();
            if (pod.isThrusting())
            {
                renderer.material = destroyMTRL;
                Fade();
                pod.SendMessage("EnemyHit");
                collider2D.enabled = false;
            }
        }
    }

    void Fade()
    {
        Color pColor = ps.startColor;
        pColor.a = 0;
        ps.startColor = pColor;
    }
}
