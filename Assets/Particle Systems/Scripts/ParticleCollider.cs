using UnityEngine;
using System.Collections;

public class ParticleCollider : MonoBehaviour {

    public LayerMask fireLayer;
    public Material aliveMTRL, destroyMTRL;

    private ParticleSystem ps;
    private Renderer renderer;
    private IEnumerator coroutine;

	// Use this for initialization
	void Awake () {
        ps = GetComponent<ParticleSystem>();
        renderer = GetComponent<Renderer>();
        renderer.material = aliveMTRL;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        //coroutine = CheckVelocity(col);
        //StartCoroutine(coroutine);
    }

    void OnTriggerStay2D (Collider2D col)
    {
        string objLayerName = LayerMask.LayerToName(col.gameObject.layer);
        if (string.Equals(objLayerName, "Player"))
        {
            var pod = col.GetComponent<DropPod>();
            if (pod.Velocity() > 0)
            {
                renderer.material = destroyMTRL;
                Fade();
                pod.SendMessage("EnemyHit");
            }
        }
    }

    void OnTriggerExit2D (Collider2D col)
    {
        //StopCoroutine(coroutine);
    }

    IEnumerator CheckVelocity (Collider2D col)
    {
        while(true)
        {
            string objLayerName = LayerMask.LayerToName(col.gameObject.layer);
            if (string.Equals(objLayerName, "Player"))
            {
<<<<<<< HEAD
                var pod = col.GetComponent<DropPod>();
                if (pod.Velocity() > 0)
                {
                    renderer.material = destroyMTRL;
                    Fade();
                    pod.SendMessage("EnemyHit");
                    yield return false;
                }
                yield return null;
=======
                r.material = destroyMTRL;
                Fade();
                player.SendMessage("EnemyHit");
                yield return false;
>>>>>>> 79877f746aa3f0380d095110086884366e0406b5
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
