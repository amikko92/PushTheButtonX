using UnityEngine;
using System.Collections;

public class ParticleCollider : MonoBehaviour {

    public LayerMask fireLayer;
    public Material aliveMTRL, destroyMTRL;

    private ParticleSystem ps;
    private Renderer r;
    private IEnumerator coroutine;

	// Use this for initialization
	void Awake () {
        ps = GetComponent<ParticleSystem>();
        r = GetComponent<Renderer>();
        r.material = aliveMTRL;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        coroutine = CheckVelocity(col);
        StartCoroutine(coroutine);
    }

    void OnTriggerExit2D (Collider2D col)
    {
        StopCoroutine(coroutine);
    }

    IEnumerator CheckVelocity (Collider2D col)
    {
        while (true)
        {
            var player = col.GetComponent<Rigidbody2D>();
            if (player.velocity.y > 0)
            {
                r.material = destroyMTRL;
                Fade();
                player.SendMessage("EnemyHit");
                yield return false;
            }
            yield return null;
        }
    }

    void Fade()
    {
        Color pColor = ps.startColor;
        pColor.a = 0;
        ps.startColor = pColor;
    }
}
