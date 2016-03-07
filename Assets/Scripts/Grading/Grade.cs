using UnityEngine;
using System.Collections;

public class Grade : MonoBehaviour {

    private float startNo;
    private int hitNumber;
    private float fuelUse;
    public float hitPrice;
    public float fuelPrice;
    public float timePrice;
    private float start;
    private float end;
    private GameObject pod;
    private float startHeight;

    private void Awake()
    {
        hitNumber = 0;
        fuelUse = 0;
        hitPrice = 50;
        fuelPrice = 15;
        timePrice = 2;
        pod = GameObject.FindGameObjectWithTag("Player");
        startHeight = pod.transform.position.y;
        startNo = startHeight * 10;
    }
    public void GotHit()
    {
        hitNumber++;
    }

    public void FuelUsage(float used)
    {
        fuelUse += used;
    }
    public void StartTime()
    {
        start = Time.time;
    }

    public void EndTime()
    {
        end = Time.time;
    }

    public int CalculateGrade()
    {
        float grade = startNo - (hitNumber * hitPrice) - (fuelUse * fuelPrice) - ((end - start) * timePrice);
        if (grade < (startHeight * 8 * 0.3))
        {
            return 0;
        }
        else if (grade < (startHeight * 8 * 0.5))
        {
            return 1;
        }
        else if (grade < (startHeight * 8 * 0.8))
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }
}
