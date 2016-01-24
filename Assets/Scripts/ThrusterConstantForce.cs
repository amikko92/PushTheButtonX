using UnityEngine;
using System.Collections;

public class ThrusterConstantForce : Thruster 
{
    [SerializeField]
    private float m_thrustForce;
    
    public override Vector3 ThrustForce()
    {
        Vector3 velocity = m_rigidbody.velocity;
        Vector3 deltaForce = Vector3.zero;

        if (Input.GetKey(KeyCode.Space))
        {
            deltaForce += Vector3.up * m_thrustForce;
        }
        
        return deltaForce;
    }
}
