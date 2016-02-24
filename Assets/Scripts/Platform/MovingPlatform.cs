using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour 
{
    [SerializeField]
    private float m_maxVelocity = 1.0f;
    
    [SerializeField]
    private Transform m_target;
    
    private ConstantForce2D m_constantForce;

    private Vector2 m_startPos;
    private Vector2 m_endPos;
    private Vector2 m_curTarget;
    private float m_distSqrDivision;

    private Vector2 m_direction;

    private float m_traveledDistSqr;

    private void Awake() 
	{
        m_startPos = transform.position;
        m_endPos = m_target.position;

        m_constantForce = GetComponent<ConstantForce2D>();

        m_direction = m_endPos - m_startPos;
        m_direction.Normalize();
        m_distSqrDivision = 1.0f / Vector2.SqrMagnitude(m_direction);
        m_curTarget = m_endPos;
	}
	
	private void Update() 
	{
        Vector2 force = Vector2.zero;

        float curDistSqr = Vector2.SqrMagnitude((Vector2)transform.position - m_curTarget);
        float step = curDistSqr * m_distSqrDivision;

        force += Vector2.Lerp(Vector2.zero, m_direction * m_maxVelocity, step);
        force += Vector2.Lerp(-m_direction * m_maxVelocity, Vector2.zero, step);
        
        m_constantForce.force = force;

        if(step <= 0.1f)
        {
            ChangeDirection();
        }
	}

    private void ChangeDirection()
    {
        m_curTarget = (m_curTarget == m_endPos) ? m_startPos : m_endPos;
        m_direction *= -1.0f;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(m_target.position, 1.0f);
    }
}
