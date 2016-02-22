using UnityEngine;
using System.Collections;

public class ThrusterConstantForce : Thruster 
{
    [SerializeField]
    private Vector2 m_thrustForce = new Vector2(0.0f, 1.0f);
    
    public override Vector2 ThrustForce()
    {
        return m_thrustForce;
    }
}
