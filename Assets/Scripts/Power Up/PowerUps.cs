using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour
{

    public DropPod sc;
    public float speed = 10f;
    private float rotx;
    private float roty;
    private float rotz;
    private ParticleSystem exp;
    private GameObject particle;
    private GameObject model;

    void Awake()
    {
        particle = GameObject.Find ("Particles");
        exp = particle.GetComponent<ParticleSystem>();
        model = GameObject.Find("Model");
    }

    void Update()
    {
        rotx = Random.Range(0.1f, 5);
        roty = Random.Range(0.1f, 5);
        rotz = Random.Range(0.1f, 5);
        transform.Rotate(speed * rotx * Time.deltaTime, speed * roty * Time.deltaTime, speed * rotz * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        GameObject other = c.gameObject;
        sc = other.GetComponent<DropPod>();
        if (other.tag.Equals("Player"))
        {
            Destroy(GetComponent<CircleCollider2D>());
            Destroy(model);
            Explode();
        }
    }
    /*void OnTriggerExit2D(Collider2D c)
	{
		sc = c.GetComponent<DropPod>();
		if (c.tag.Equals("Player"))
		{
			Destroy(gameObject);
		}
	}*/
    void Explode()
    {
        
        exp.Play();
        exp.Emit(15);
        Destroy(gameObject, exp.duration);
    }
}