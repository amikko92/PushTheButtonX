using UnityEngine;
using System.Collections;

public class RayShooter 
{
    private RaycastHit m_hitInfo;
    private bool m_hit;

    public RayShooter()
    {
        m_hit = false;
    }

    public void Shoot(Vector3 origin, Vector3 direction)
    {
        Ray ray = new Ray(origin, direction);
        m_hit = Physics.Raycast(ray, out m_hitInfo);
    }

    public void Shoot(Vector3 origin, Vector3 direction, int mask)
    {
        Ray ray = new Ray(origin, direction);
        m_hit = Physics.Raycast(ray, out m_hitInfo, float.PositiveInfinity, mask);
    }
    
    public float IntersectionDistance()
    {
        return m_hitInfo.distance;
    }

    public Vector3 IntersectionPoint()
    {
        return m_hitInfo.point;
    }

    public Vector3 IntersectionNormal()
    {
        return m_hitInfo.normal;
    }

    public Transform IntersectedTransform()
    {
        return m_hitInfo.transform;
    }

    public bool Hit()
    {
        return m_hit;
    }
}