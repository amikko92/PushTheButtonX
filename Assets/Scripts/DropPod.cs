using UnityEngine;
using System.Collections;

public class DropPod : MonoBehaviour 
{
    [SerializeField]
    private Thruster m_thruster;

    [SerializeField]
    private float m_maxLandingVelocity = 1.0f;

    private int m_fuel = 100;

    private bool m_shield = false;

    [SerializeField, Range(0.0f, 1.0f)]
    private float m_gravityScaleOffset = 0.5f;

    private float m_startAltitude;

    private Transform m_transform;
    private Rigidbody2D m_rigidbody2D;
    private BoxCollider2D m_boxCollider2D;

    private RayShooter2D m_rayShooter2D;

    [SerializeField]
    private LayerMask m_groundMask;

    // E-man: Get ThrusterFlame object on awake
    private GameObject thrusterFlame;

	private void Awake() 
	{
        m_transform = transform;
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_thruster = GetComponent<Thruster>();
        m_boxCollider2D = GetComponent<BoxCollider2D>();

        m_startAltitude = Altitude();

        // E-man - Begin
        thrusterFlame = GameObject.Find("ThrusterFlame");

        if (thrusterFlame)
        {
            thrusterFlame.SetActive(false);
        }
        else
        {
            Debug.Log("DopPod::Awake(), Hey buddy! Something went wrong!");
        }
        // E-man - End

        
	}
	
	private void FixedUpdate()
	{
        m_rigidbody2D.gravityScale = GravityScale();

        // E-man: Changed this to crappy temporal fix while we wait for input manager
        bool spaceKey = Input.GetKey(KeyCode.Space);

        if (spaceKey)
        {
            FireThruster();
        }

        thrusterFlame.SetActive(spaceKey);
        
    }

    public float Altitude()
    {
        return m_transform.position.y;
    }

    public float Velocity()
    {
        return m_rigidbody2D.velocity.magnitude;
    }

    public int Fuel()
    {
        return m_fuel;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        string layerName = LayerMask.LayerToName(other.layer);

        if( string.Equals(layerName, "Ground") )
        {
            bool land = LandingSequence(collision);
            if(land)
            {
                LevelComplete();
            }
            else
            {
                KillMe();
            }
        }
        
        if (string.Equals(layerName, "Platform"))
        {
            bool land = LandingSequence(collision);
            if (!land)
            {
                KillMe();
            }
        }

        if (string.Equals(layerName, "Enemy"))
        {
            if(m_shield)
            {
                RemoveShield();
            }
            else
            {
                KillMe();
            }
        }
    }

    private bool LandingSequence(Collision2D collision)
    {
        // TODO: Calculate direction of collision. Ray casting?

        return LandVelocityCheck();
    }

    private bool LandVelocityCheck()
    {
        // Compare Current velocity against maximum allowed landing velocity
        return (m_maxLandingVelocity * m_maxLandingVelocity) > m_rigidbody2D.velocity.sqrMagnitude; ;
    }

    private void KillMe()
    {
        Debug.Log("BOOM!");
        // TODO: Explosions and game over event
    }

    private void LevelComplete()
    {
        Debug.Log("Landed!");
        // TODO: Send level clear event
    }

    private void RemoveShield()
    {
        // Have no shield. Do nothing
        if (!m_shield)
            return;

        m_shield = false;

        // TODO: Shield remove effects here
    }

    private void AddShield()
    {
        // Already have shield. Do nothing
        if (m_shield)
            return;

        m_shield = true;

        // TODO: Shield activation effects here
    }

    public Vector3 PodBottomCenter()
    {
        Vector3 bottomCenter = transform.position;
        bottomCenter.y += m_boxCollider2D.size.y * 0.5f;
        return bottomCenter;
    }

    private float GravityScale()
    {
        float altitude = Mathf.Min(Altitude(), m_startAltitude);
        float gravityScale =  m_gravityScaleOffset + (1.0f - (altitude / m_startAltitude));
        return gravityScale;
    }

    private void FireThruster()
    {
        m_rigidbody2D.AddForce(m_thruster.ThrustForce());       
    }
}
