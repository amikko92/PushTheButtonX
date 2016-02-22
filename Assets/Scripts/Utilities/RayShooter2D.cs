using UnityEngine;
using System.Collections;

public class RayShooter2D 
{
    private RaycastHit2D m_hitInfo;
    private bool m_hit;
    public bool Hit
    {
        get {
            return (m_hitInfo.transform != null);
            //m_hit;
        }
    }

    public RayShooter2D()
    {
        m_hit = false;
    }

    public void Shoot(Vector2 origin, Vector2 direction)
    {
        m_hitInfo = Physics2D.Raycast(origin, direction);
    }

    public void Shoot(Vector2 origin, Vector2 direction, int mask)
    {
        m_hitInfo = Physics2D.Raycast(origin, direction, float.PositiveInfinity, mask);
    }

    public void Shoot(Vector2 origin, Vector2 direction, int mask, float distance)
    {
        m_hitInfo = Physics2D.Raycast(origin, direction, distance, mask);
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
}