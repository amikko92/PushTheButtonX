using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditorInternal;
using System.Reflection;
using CurveExtended;

public class CameraMovement : MonoBehaviour
{
    public AnimationCurve curve;
    private GameObject pod;
    private DropPod script;
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
    public float initOffset = -1.0f;
    public float midSpeedOffset = -0.0f;
    public float slowOffset = 2.0f;
    public float slowestOffset = 4.0f;
    public float upOffset = 4.0f;
    public float stillOffset = 4.0f;
    public float fastOffset = -2.0f;
    public float scartScrollDistancePS = 10.0f;
    public float fast = 12.0f;
    public float mid = 6.0f;
    public float slow = 4.0f;
    public float slowest = 1.0f;
    public float offsetChangeSpeed = 1.0f;
    private float location;
    private int index;

    
    void Awake()
    {
        pod = GameObject.FindGameObjectWithTag("Player");
        script = pod.GetComponent<DropPod>();
        startPos = pod.transform.position;
        explosion = false;
        play = false;
        min = -0.21f;
        max = 0.21f;
        offset = midSpeedOffset;
        location = 0.7f;
        curve = new AnimationCurve();
        Vector3 temp = transform.position;
        temp.y = 0.7f;
        transform.position = temp;
        if (!startOfGame)
        {
            temp.y = startPos.y;
            transform.position = temp;
        }
        else
        {
            for (index = 0; location < startPos.y; index++)
            {
                curve.AddKey(KeyframeUtil.GetNew(Time.time + index, location, TangentMode.Linear));
                location += scartScrollFPS;
            }
            curve.AddKey(KeyframeUtil.GetNew(Time.time + index, startPos.y, TangentMode.Linear));
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
                print("entered");
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
                                    offset = Mathf.Lerp(offset, stillOffset, offsetChangeSpeed * Time.deltaTime);
                                }
                                else if(speed < -0.1f)
                                {
                                    offset = Mathf.Lerp(offset, upOffset, offsetChangeSpeed * Time.deltaTime);
                                }
                                else
                                {
                                    offset = Mathf.Lerp(offset, slowestOffset, offsetChangeSpeed * Time.deltaTime);
                                }
                            }
                            else
                            {
                                offset = Mathf.Lerp(offset, slowOffset, offsetChangeSpeed * Time.deltaTime);
                            }
                        }
                        else
                        {
                            offset = Mathf.Lerp(offset, midSpeedOffset, offsetChangeSpeed * Time.deltaTime);
                        }
                    }
                    else if (speed > fast)
                    {
                        offset = Mathf.Lerp(offset, fastOffset, offsetChangeSpeed * Time.deltaTime);
                    }
                    else
                    {
                        offset = initOffset;
                    }
                    if(transform.position.y >= (startPos.y))
                    {
                        offset = Mathf.Lerp(offset, fastOffset, offsetChangeSpeed * Time.deltaTime);
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
        startOfGame = true;
        for (int i = 0; i <= index; i++)
        {
            curve.RemoveKey(i);
        }
    }
}