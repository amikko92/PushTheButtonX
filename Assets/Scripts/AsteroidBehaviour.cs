using UnityEngine;
using System.Collections;

public class AsteroidBehaviour : MonoBehaviour {

    private Vector3 startPos;

    void OnEnable()
    {
       startPos = transform.position;
    }

	// Update is called once per frame
	void Update () {

        if (transform.position.x > 15 || transform.position.x < -15)
        {
            gameObject.SetActive(false);
        }

        else
        {
            if (startPos.x <= 0)
            {
                transform.Translate(0.1f, 0, 0);
            }

            else
            {
                transform.Translate(-0.1f, 0, 0);
            }
        }
         
	}
}
