using UnityEngine;
using System.Collections;

public class DropPod : MonoBehaviour 
{
    [SerializeField]
    Thruster m_thruster;

    private float m_fuel = 1.0f;

    private Transform m_transform;
    private Rigidbody2D m_rigidbody2D;

    private RayShooter2D m_rayShooter2D;

    [SerializeField]
    private LayerMask m_groundMask;

	private void Awake() 
	{
        m_transform = transform;
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_thruster = GetComponent<Thruster>();
	}
	
	private void FixedUpdate()
	{
        if(Input.GetKey(KeyCode.Space))
        {
            m_rigidbody2D.AddForce(m_thruster.ThrustForce());
        }
    }

    public float Altitude()
    {
        return m_transform.position.y;
    }

    public float Velocity()
    {
        return m_rigidbody2D.velocity.magnitude;
    }

    public float Fuel()
    {
        return m_fuel;
    }
}
