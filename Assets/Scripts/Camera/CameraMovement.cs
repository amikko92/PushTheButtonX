using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    private GameObject pod;
    private float smoothSpeed = 1000.0f;
    public bool startOfGame;
    public float scrollSpeed = 0.2f;
    private Vector3 startPos;
    private float fast;
    private bool explosion;
    private float dest;
    private float min;
    private float max;
    private float newx;
    private float speed;
    private float offset;
    private bool play;
    public float initOffset = -1.0f;
    public float midSpeedOffset = 0.0f;
    public float slowOffset = 2.0f;
    public float upAndSlowestOffset = 4.0f;
    public float fastOffset = -2.0f;
    //X offset is the offset for x when the pod moves to __ amount to one side of the camera. after __, camera starts to follow
    //pod rather than letting it slide to the side of the camera.
    public float xOffset = 15.0f;



    void Awake()
    {
        pod = GameObject.FindGameObjectWithTag("Player");
        startPos = pod.transform.position;
        //fast = set maxSpeed;
        explosion = false;
        play = false;
        min = -0.21f;
        max = 0.21f;
        offset = initOffset;
        if (!startOfGame)
        {
            Vector3 temp = pod.transform.position;
            temp.z = transform.position.z;
            temp.x = transform.position.x;
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
        if (Time.timeScale != 0)
        {
            if (startOfGame)
            {
                dest = Mathf.Lerp(transform.position.y, startPos.y, scrollSpeed * Time.deltaTime);
                transform.position = new Vector3(transform.position.x, dest, transform.position.z);
            }
            else if (pod && play)
            {
                if (transform.position.y <= (startPos.y + 5.0f))
                {
                    if ((explosion))/*pod.speed >= fast) || explosion)*/
                    {
                        newx = Mathf.PerlinNoise(transform.position.x * Time.time * min, transform.position.x * Time.time * max);
                        dest = Mathf.PerlinNoise(transform.position.y * Time.time * min, transform.position.y * Time.time * max);
                        dest = Mathf.Lerp(dest, pod.transform.position.y, smoothSpeed * Time.deltaTime);
                        transform.position = new Vector3(newx, dest + offset, transform.position.z);
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
                        /*newx = transform.position.x;
                        if (pod.transform.position.x <= (transform.position.x - xOffset))
                        {
                            newx = pod.transform.position.x + xOffset;
                        }
                        else if (pod.transform.position.x >= (transform.position.x + xOffset))
                        {
                            newx = pod.transform.position.x - xOffset;
                        }*/

                        dest = Mathf.Lerp(transform.position.y, pod.transform.position.y, smoothSpeed * Time.deltaTime);
                        transform.position = new Vector3(transform.position.x, dest + offset, transform.position.z);

                    }
                }
            }
        }
    }
    public bool AtTop()
    {
        if (transform.position.y >= (startPos.y+5.0f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void GameStart()
    {
        startOfGame = true;
    }
    public void GamePlay()
    {
        play = true;
        startOfGame = false;
    }
    public void EndGame()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}