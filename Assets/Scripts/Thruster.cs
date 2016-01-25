using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public abstract class Thruster : MonoBehaviour 
{
    protected Rigidbody m_rigidbody;

    protected virtual void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    public abstract Vector3 ThrustForce();
}
