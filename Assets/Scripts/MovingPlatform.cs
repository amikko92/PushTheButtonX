using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour 
{
    [SerializeField]
    private float m_velocity;

    private Rigidbody2D m_rigidbody2D;

    private float m_time;
    private Vector2 m_direction;

	private void Awake() 
	{
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_direction = Vector2.right;
	}
	
	private void Update() 
	{
        m_time += Time.deltaTime;
	}

    private void FixedUpdate()
    {
        m_rigidbody2D.velocity = m_direction * m_velocity;
        if(m_time >= 4.0f)
        {
            m_direction *= -1;
            m_time = 0.0f;
        }
    }
}
