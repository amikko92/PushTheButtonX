using UnityEngine;
using System.Collections;

public class DropPod : MonoBehaviour 
{
    //[SerializeField]
    //private float m_thrustForce;
    //
    //[SerializeField]
    //private float m_maxThrustForce;
    //
    //[SerializeField]
    //private float m_accelerationTime = 1.0f;
    //
    //private float m_acceleration;
    //private float m_accelerationFactor;

    [SerializeField]
    Thruster m_thruster;

    private Rigidbody m_rigidbody;

	private void Awake() 
	{
        m_rigidbody = GetComponent<Rigidbody>();
        m_thruster = GetComponent<Thruster>();
        //m_accelerationFactor = 1.0f / m_accelerationTime;
	}
	
	private void FixedUpdate()
	{
        m_rigidbody.AddForce(m_thruster.ThrustForce());
    }
}
