using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour
{

    public DropPod sc;
    public float speed = 10f;


    void Update()
    {
        transform.Rotate(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        GameObject other = c.gameObject;
        sc = other.GetComponent<DropPod>();
        if (other.tag.Equals("Player"))
        {
            Destroy(gameObject);
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
}