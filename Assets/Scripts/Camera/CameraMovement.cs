using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditorInternal;
using System.Reflection;
using CurveExtended;

public class CameraMovement : MonoBehaviour
{
    public AnimationCurve curve;
    private Keyframe[] frames;
    private GameObject pod;
    private float smoothSpeed = 1000.0f;
    public bool startOfGame;
    private Vector3 startPos;
    private bool explosion;
    private float dest;
    private float min;
    private float max;
    private float newx;
    private float speed;
    private float offset;
    private bool play;
    public float midSpeedOffset = -1.0f;
    public float slowOffset = 2.0f;
    public float slowestOffset = 4.0f;
    public float upOffset = 4.0f;
    public float stillOffset = 4.0f;
    public float fastOffset = -2.0f;
    public float scartScrollFPS = 0.5f;
    public float fast = 12.0f;
    public float mid = 6.0f;
    public float slow = 4.0f;
    public float slowest = 1.0f;
   

    void Awake()
    {
        pod = GameObject.FindGameObjectWithTag("Player");
        startPos = pod.transform.position;
        explosion = false;
        play = false;
        min = -0.21f;
        max = 0.21f;
        offset = midSpeedOffset;
        if (!startOfGame)
        {
            Vector3 temp = transform.position;
            temp.y = startPos.y;
            transform.position = temp;
        }
        else
        {
            float loc = 0;
            int i;
            curve.AddKey(KeyframeUtil.GetNew(0, transform.position.y, TangentMode.Linear));
            for (i = 1; loc < startPos.y; i++)
            {
                curve.AddKey(KeyframeUtil.GetNew(i, loc, TangentMode.Linear));
                loc += 10;
            }
            curve.AddKey(KeyframeUtil.GetNew(i, startPos.y, TangentMode.Linear));
            curve.UpdateAllLinearTangents();
        }
        
    }
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
                Vector3 local = transform.position;        
                local.y = curve.Evaluate(Time.time);
                transform.position = local;
            }
            else if (pod && play)
            {
                if ((explosion))
                {
                    newx = Mathf.PerlinNoise(transform.position.x * Time.time * min, transform.position.x * Time.time * max);
                    dest = Mathf.PerlinNoise(transform.position.y * Time.time * min, transform.position.y * Time.time * max);
                    dest = Mathf.Lerp(dest, pod.transform.position.y, smoothSpeed * Time.deltaTime);
                    transform.position = new Vector3(newx, dest + offset, transform.position.z);
                }
                else
                {
                    if (speed < mid)
                    {
                        if (speed < slow)
                        {
                            if (speed < slowest)
                            {
                                if( (speed < 0.1f) && (speed > -0.1f))
                                {
                                    offset = Mathf.Lerp(offset, stillOffset, Time.deltaTime);
                                }
                                else if(speed < -0.1f)
                                {
                                    offset = Mathf.Lerp(offset, upOffset, Time.deltaTime);
                                }
                                else
                                {
                                    offset = Mathf.Lerp(offset, slowestOffset, Time.deltaTime);
                                }
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
                    else if (speed > fast)
                    {
                        offset = Mathf.Lerp(offset, fastOffset, Time.deltaTime);
                    }
                    if(transform.position.y >= (startPos.y))
                    {
                        offset = Mathf.Lerp(offset, fastOffset, Time.deltaTime);
                    }
                    dest = Mathf.Lerp(transform.position.y, pod.transform.position.y, smoothSpeed * Time.deltaTime);
                    transform.position = new Vector3(transform.position.x, dest + offset, transform.position.z);
                }
                
            }
        }
    }
    public bool AtTop()
    {
        if (transform.position.y >= (startPos.y - 0.5f))
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