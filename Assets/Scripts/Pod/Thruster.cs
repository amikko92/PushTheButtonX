using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Thruster : MonoBehaviour 
{
    protected Rigidbody2D m_rigidbody2D;

    protected virtual void Awake()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public abstract Vector2 ThrustForce();
}
