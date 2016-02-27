using UnityEngine;
using System.Collections;

public class AsteroidBehaviour : MonoBehaviour {

    [SerializeField]
    private Vector3 translationFactor = new Vector3(1.0f, 0, 0);

    private Vector3 startPos;

    //TOFDO
    //make this crap work
    private Vector3 rotation = new Vector3(0, 0 , -1);

    void OnEnable()
    {
       startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //TOFDO
        //make this crap work
        transform.Rotate(rotation * 50 * Time.deltaTime, Space.Self);

            if (startPos.x <= 0)
            {
                transform.Translate(translationFactor * Time.deltaTime, Space.World);
            }

            else
            {
                transform.Translate(-translationFactor * Time.deltaTime, Space.World);
            }        
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("RightBound"))
        {
            gameObject.SetActive(false);
        }
    }
}
