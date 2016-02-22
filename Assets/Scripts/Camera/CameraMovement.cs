using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
	private GameObject pod;
	private float smoothSpeed = 200.0f;
	public bool startOfGame = true;
	public float scrollSpeed = 0.4f;
	private Vector3 startPos;
	private float fast;
	private bool explosion;
	private float dest;
	private float min;
	private float max;
	private float newx;
	private float speed;
	private float offset;
	public float initOffset = -1.0f;
	public float midSpeedOffset = 0.0f;
	public float slowOffset = 4.0f;
	public float upAndSlowestOffset = 7.0f;
	public float fastOffset = -3.0f;
	//X offset is the offset for x when the pod moves to __ amount to one side of the camera. after __, camera starts to follow
	//pod rather than letting it slide to the side of the camera.
	public float xOffset = 5.0f;
	
	
	void Awake()
	{
		pod = GameObject.FindGameObjectWithTag("Player");
		startPos = pod.transform.position;
		//fast = set maxSpeed;
		explosion = false;
		min = -0.21f;
		max = 0.21f;
		offset = initOffset;
		if (!startOfGame)
		{
			Vector3 temp = pod.transform.position;
			temp.z = transform.position.z;
			transform.position = temp;
		}
	}
	Vector3 lastPosition = Vector3.zero;
	void FixedUpdate()
	{
		speed = pod.GetComponent<Rigidbody2D>().velocity.y * -1;
	}
	void LateUpdate()
	{
		if (startOfGame)
		{
			pod.transform.position = startPos;
			dest = Mathf.Lerp(transform.position.y, startPos.y + 1.0f, scrollSpeed * Time.deltaTime);
			transform.position = new Vector3(transform.position.x, dest, transform.position.z);
			if ((transform.position.y == startPos.y) || (transform.position.y > startPos.y - 1.0f))
			{
				startOfGame = false;
			}
		}
		else if (pod)
		{
			if (transform.position.y <= (startPos.y + 50.0f))
			{
				if ((explosion))/*pod.speed >= fast) || explosion)*/
				{
					newx = Mathf.PerlinNoise(transform.position.x * Time.time * min, transform.position.x * Time.time * max);
					dest = Mathf.PerlinNoise(transform.position.y * Time.time * min, transform.position.y * Time.time * max);
					dest = Mathf.Lerp(dest, pod.transform.position.y, smoothSpeed * Time.deltaTime);
					transform.position = new Vector3(transform.position.x, dest + offset, transform.position.z);
				}
				else
				{
                    if (speed < 6.0f)
                    {
                        if (speed < 4.0f)
                        {
                            if (speed < 1.0f)
                            {
                                offset = Mathf.Lerp(offset, upAndSlowestOffset, Time.deltaTime);
                            }
                            else
                            {
                                offset = Mathf.Lerp(offset, slowOffset, Time.deltaTime);
                            }
                        }
                        else
                        {
                            offset = Mathf.Lerp(offset, midSpeedOffset, Time.deltaTime);
                        }
                    }
                    else if (speed > 12.0f)
                    {
                        offset = Mathf.Lerp(offset, fastOffset, Time.deltaTime);
                    }
					newx = transform.position.x;
					if (pod.transform.position.x <= (transform.position.x - xOffset))
					{
						newx = pod.transform.position.x + xOffset;
					}
					else if (pod.transform.position.x >= (transform.position.x + xOffset))
					{
						newx = pod.transform.position.x - xOffset;
					}
					dest = Mathf.Lerp(transform.position.y, pod.transform.position.y, smoothSpeed * Time.deltaTime);
					transform.position = new Vector3(transform.position.x, dest + offset, transform.position.z);
				}
			}
		}
	}
}
