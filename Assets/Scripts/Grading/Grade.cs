using UnityEngine;
using System.Collections;

public class Grade : MonoBehaviour {

    private float startNo;
    private int hitNumber;
    private float fuelUse;
    public float hitPrice;
    public float fuelPrice;
    private float start;
    private float end;

    private void Awake()
    {
        hitNumber = 0;
        fuelUse = 0;
        startNo = 100;
        hitPrice = 10;
        fuelPrice = 1;
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
        float grade = startNo - (hitNumber * hitPrice) - (fuelUse * fuelPrice) - (end - start);
        if(grade < 30)
        {
            return 1;
        }
        else if (grade < 60)
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }
}
