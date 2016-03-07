using UnityEngine;
using System.Collections;
//using UnityEditor;
//using UnityEditorInternal;
using System.Reflection;
using CurveExtended;

public class CameraMovement : MonoBehaviour
{
    public AnimationCurve curve;
    private GameObject pod;
    private DropPod script;
    private float smoothSpeed = 1000.0f;
    public bool startOfGame;
    private Vector3 podPos;
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
    public float upSlowOffset = 2.0f;
    public float upOffset = 4.0f;
    public float stillOffset = 4.0f;
    public float fastOffset = -2.0f;
    public float maxVelocity = 1.0f;
    public float fast = 12.0f;
    public float mid = 6.0f;
    public float slow = 4.0f;
    public float slowest = 1.0f;
    public float offsetChangeSpeed = 1.0f;
    private float location;
    private int index;

    private Vector3 startPos;
    private float timeStep;
    private float timer;

    void Awake()
    {
        pod = GameObject.FindGameObjectWithTag("Player");
        script = pod.GetComponent<DropPod>();
        podPos = pod.transform.position;
        explosion = false;
        play = false;
        min = -0.21f;
        max = 0.21f;
        offset = midSpeedOffset;
        location = 0.7f;
        //curve = new AnimationCurve();
        Vector3 temp = transform.position;
        temp.y = 0.7f;
        transform.position = temp;
        if (!startOfGame)
        {
            temp.y = podPos.y;
            transform.position = temp;
        }
        else
        {
            /*for (index = 0; location < startPos.y; index++)
            {
                curve.AddKey(KeyframeUtil.GetNew(Time.time + index, location, TangentMode.Linear));
                location += scartScrollDistancePS;
            }
            curve.AddKey(KeyframeUtil.GetNew(Time.time + index, startPos.y, TangentMode.Linear));
            curve.UpdateAllLinearTangents();*/
        }

        startPos = transform.position;
        timeStep = 1.0f / ((podPos.y - startPos.y) / maxVelocity);
        timer = 0.0f;
    }
    void FixedUpdate()
    { 
        speed = pod.GetComponent<Rigidbody2D>().velocity.y * -1;
        offset = CalculateOffset();
    }
    void LateUpdate()
    {
        if (Time.timeScale != 0)
        {
            if (startOfGame)
            {
                Vector3 local = transform.position;

                timer += Time.deltaTime;
                float delta = curve.Evaluate(timer * timeStep);
                local.y = delta * podPos.y;
                
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
                    dest = Mathf.Lerp(transform.position.y, pod.transform.position.y, smoothSpeed * Time.deltaTime);
                    transform.position = new Vector3(transform.position.x, dest + offset, transform.position.z);
                }
                
            }
        }
    }
    private float CalculateOffset()
    {
        float os;
        if (speed < mid)
        {
            if (speed < slow)
            {
                if (speed < slowest)
                {
                    if ((speed < 0.1f) && (speed > -0.1f))
                    {
                        os = Mathf.Lerp(offset, stillOffset, offsetChangeSpeed * Time.deltaTime);
                    }
                    else if (speed < -0.1f)
                    {
                        if (speed < (-1 * slowest))
                        {
                            os = Mathf.Lerp(offset, upSlowOffset, offsetChangeSpeed * Time.deltaTime);
                        }
                        else
                        {
                            os = Mathf.Lerp(offset, upOffset, offsetChangeSpeed * Time.deltaTime);
                        }
                    }
                    else
                    {
                        os = Mathf.Lerp(offset, slowestOffset, offsetChangeSpeed * Time.deltaTime);
                    }
                }
                else
                {
                    os = Mathf.Lerp(offset, slowOffset, offsetChangeSpeed * Time.deltaTime);
                }
            }
            else
            {
                os = Mathf.Lerp(offset, midSpeedOffset, offsetChangeSpeed * Time.deltaTime);
            }
        }
        else if (speed > fast)
        {
            os = Mathf.Lerp(offset, fastOffset, offsetChangeSpeed * Time.deltaTime);
        }
        else
        {
            os = Mathf.Lerp(offset, initOffset, offsetChangeSpeed * Time.deltaTime);
        }
        if (transform.position.y >= (podPos.y))
        {
            os = Mathf.Lerp(offset, fastOffset, offsetChangeSpeed * Time.deltaTime);
        }
        return os;
    }
    public bool AtTop()
    {
        if (transform.position.y >= (podPos.y - 0.5f))
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