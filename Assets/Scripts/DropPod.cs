using UnityEngine;
using System.Collections;

public class DropPod : MonoBehaviour 
{
    [SerializeField]
    Thruster m_thruster;

    private Rigidbody2D m_rigidbody2D;

    private RayShooter2D m_rayShooter2D;

    [SerializeField]
    private LayerMask m_groundMask;

	private void Awake() 
	{
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_thruster = GetComponent<Thruster>();
	}
	
	private void FixedUpdate()
	{
        m_rayShooter2D.Shoot(transform.position, Vector2.down);
        if(m_rayShooter2D.Hit)
        {

        }

        if(Input.GetKey(KeyCode.Space))
        {
            m_rigidbody2D.AddForce(m_thruster.ThrustForce());
        }
    }
}
