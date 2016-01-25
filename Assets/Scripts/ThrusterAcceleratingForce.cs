using UnityEngine;
using System.Collections;

public class ThrusterAcceleratingForce : Thruster 
{
    [SerializeField]
    private float m_maxThrustForce;

    [SerializeField]
    private float m_accelerationTime = 1.0f;

    private float m_acceleration;
    private float m_accelerationFactor;

    protected override void Awake()
    {
        base.Awake();
        m_accelerationFactor = 1.0f / m_accelerationTime;
    }

    public override Vector3 ThrustForce()
    {
        Vector3 velocity = m_rigidbody.velocity;
        Vector3 deltaForce = Vector3.zero;

        if (Input.GetKey(KeyCode.Space))
        {
            m_acceleration += m_accelerationFactor * Time.fixedDeltaTime;
            deltaForce += Vector3.up * Mathf.Lerp(0.0f, m_maxThrustForce, m_acceleration);
        }
        else
        {
            m_acceleration = 0.0f;
        }

        return deltaForce;
    }
}
