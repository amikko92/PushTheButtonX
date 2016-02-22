using UnityEngine;
using System.Collections;

public class AsteroidBehaviour : MonoBehaviour {

    [SerializeField]
    private Vector3 translationFactor = new Vector3(1.0f, 0, 0);

    private Vector3 startPos;

    void OnEnable()
    {
       startPos = transform.position;
    }

	// Update is called once per frame
	void Update () {

        if (transform.position.x > 50 || transform.position.x < -50)
        {
            gameObject.SetActive(false);
        }

        else
        {
            if (startPos.x <= 0)
            {
                transform.Translate(translationFactor * Time.deltaTime);
            }

            else
            {
                transform.Translate(-translationFactor * Time.deltaTime);
            }
        }
         
	}
}
