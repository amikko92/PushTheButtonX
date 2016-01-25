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

    private RayShooter m_rayShooter;

    [SerializeField]
    private LayerMask m_groundMask;

	private void Awake() 
	{
        m_rigidbody = GetComponent<Rigidbody>();
        m_thruster = GetComponent<Thruster>();
        //m_accelerationFactor = 1.0f / m_accelerationTime;

        m_rayShooter = new RayShooter();
        m_rayShooter.Shoot(transform.position, Vector3.down, m_groundMask.value);
        if(m_rayShooter.Hit())
        {
            Debug.Log(m_rayShooter.IntersectionDistance());
        }
	}
	
	private void FixedUpdate()
	{
        m_rigidbody.AddForce(m_thruster.ThrustForce());
    }
}
