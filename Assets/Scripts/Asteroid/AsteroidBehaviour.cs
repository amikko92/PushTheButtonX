using UnityEngine;
using System.Collections;

public class AsteroidBehaviour : MonoBehaviour {

    [SerializeField]
    private Vector3 translationFactor = new Vector3(1.0f, 0, 0);

    private Vector3 startPos;

    //TOFDO
    [SerializeField]
    private Vector3 rotation = new Vector3(0, 0 , -1);

    private Vector3 translation;

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
                translation = translationFactor * Time.deltaTime;
                transform.Translate(translation, Space.World);
            }

            else
            {
                translation = -translationFactor * Time.deltaTime;
                transform.Translate(translation, Space.World);
            }        
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("RightBound") || collider.CompareTag("LeftBound"))
        {
            gameObject.SetActive(false);
        }
    }

    public Vector3 GetTranslation()
    {
        return translation;
    }
}
