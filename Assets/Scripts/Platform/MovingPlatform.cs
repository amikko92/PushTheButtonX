using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour 
{
    [SerializeField]
    private float m_maxVelocity = 1.0f;

    [SerializeField]
    private float m_smooth = 1.0f;
    
    [SerializeField]
    private Transform m_target;

    [SerializeField]
    private LayerMask m_landableMask;
    
    private Rigidbody2D m_rigidbody2D;

    private Vector2 m_startPos;
    private Vector2 m_endPos;
    private Vector2 m_curTarget;

    Vector2 m_velocity;

    private float m_traveledDistSqr;

    private OnPlatformBehaviour m_objOn;

    private const float m_minDist = 0.01f;

    private AsteroidBehaviour asteroidBh;
    
    private void Awake() 
	{
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_velocity = Vector2.zero;
        m_objOn = null;

        if (m_target == null)
        {
            asteroidBh = transform.root.GetComponent<AsteroidBehaviour>();
            return;
        }

        m_startPos = transform.position;
        m_endPos = m_target.position;
        m_curTarget = m_endPos;
        
	}
	
	private void Update() 
	{
        if (m_objOn != null)
        {
            if (asteroidBh == null)
                m_objOn.Translate(m_velocity * Time.deltaTime);
            else
                m_objOn.Translate(asteroidBh.GetTranslation());
        }

        if (m_target == null)
            return;

        transform.position = Vector2.SmoothDamp(transform.position, m_curTarget, ref m_velocity, m_smooth, m_maxVelocity, Time.deltaTime);
        
        float curDistSqr = Vector2.SqrMagnitude((Vector2)transform.position - m_curTarget);
        if (curDistSqr <= m_minDist)
        {
            ChangeDirection();
        }
	}

    private void ChangeDirection()
    {
        m_curTarget = (m_curTarget == m_endPos) ? m_startPos : m_endPos;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int mask = m_landableMask.value;
        int layer = collision.gameObject.layer;
        
        if(BitMask.Contains(mask, layer))
        {
            GameObject go = collision.gameObject;
            m_objOn = go.GetComponent<OnPlatformBehaviour>();
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        int mask = m_landableMask.value;
        int layer = collision.gameObject.layer;

        if (BitMask.Contains(mask, layer))
        {
            Vector2 f = m_velocity * m_rigidbody2D.mass;
            m_objOn.AddForce(f);
            m_objOn = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("RightBound") || collider.CompareTag("LeftBound"))
        {
            gameObject.SetActive(false);
        }
    }
}
