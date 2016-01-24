using UnityEngine;
using System.Collections;

using System;

public class RayMissException : Exception
{
    public override string ToString()
    {
        return "Ray did not hit anything";
    }
}

public class RayShooter 
{
    public RayShooter()
    {
    }

    public float DistanceIntersection(Vector3 origin, Vector3 direction, int mask)
    {
        Ray ray = new Ray(origin, direction);
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(ray, out hitInfo, float.PositiveInfinity, mask);
        
        if(!hit)
        {
            throw new RayMissException();
        }

        return hitInfo.distance;
    }
    

}
