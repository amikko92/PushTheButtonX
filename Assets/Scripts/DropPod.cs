using UnityEngine;
using System.Collections;

public class DropPod : MonoBehaviour 
{
    [SerializeField]
    private Thruster m_thruster;

    [SerializeField]
    private float m_maxLandingVelocity = 1.0f;

    [SerializeField, Range(0.0f, m_maxFuel)]
    private float m_fuel = m_maxFuel;
    
    [SerializeField, Range(0.0f, m_maxFuel)]
    private float m_fuelUsePerSecond = 1.0f;

    public const float m_maxFuel = 100.0f;

    [Space(10)]

    [SerializeField, Range(0.0f, 1.0f)]
    private float m_gravityScaleOffset = 0.5f;

    private bool m_shield = false;

    
    private float m_startAltitude;

    private Transform m_transform;
    private Rigidbody2D m_rigidbody2D;
    private BoxCollider2D m_boxCollider2D;

    private RayShooter2D m_rayShooter2D;

    [SerializeField]
    private LayerMask m_groundMask;
    
    // Raycast members
    [SerializeField]
    private int m_totalVerticalRays = 5;
    private float m_verticalRayInterval;
    private float m_rayDistance = 0.5f;
    private float m_skinWidth = 0.1f;
    private Vector2 m_bottomLeft;

    // E-man: Get ThrusterFlame object on awake
    private GameObject thrusterFlame;

    private AudioSource[] audioSources;

    private PodState m_objectState;
    
	private void Awake() 
	{
        m_transform = transform;
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_thruster = GetComponent<Thruster>();
        m_boxCollider2D = GetComponent<BoxCollider2D>();

        m_rayShooter2D = new RayShooter2D();

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

        // Set up raycast collision check
        Vector2 size = m_boxCollider2D.size;
        Vector3 scale = transform.localScale;
        float width = size.x * Mathf.Abs(scale.x) - (2.0f * m_skinWidth);
        m_verticalRayInterval = width / (m_totalVerticalRays - 1);

        audioSources = GetComponents<AudioSource>();
        m_objectState = GetComponent<PodState>();
    }

	private void FixedUpdate()
	{
        m_rigidbody2D.gravityScale = GravityScale();
        
        m_objectState.UpdateState();
    }


    public float Altitude()
    {
        return m_transform.position.y;
    }

    public float Velocity()
    {
        return m_rigidbody2D.velocity.y;
    }

    public float Fuel()
    {
        return m_fuel;
    }

    public void AddFuel(float amount)
    {
        m_fuel = Mathf.Clamp(m_fuel + amount, 0.0f, m_maxFuel);
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

        if(string.Equals(layerName, "Obstacle"))
        {
            Debug.Log("Cloud explosion");
            if (m_rigidbody2D.velocity.y > 0)
            {
                KillMe();
                Debug.Log("Cloud explosion 4 real");
            }
        }
    }

    private bool LandVelocityCheck()
    {
        // If current vertical velocity is within the allowed landing velocity
        return (m_maxLandingVelocity > Mathf.Abs(m_rigidbody2D.velocity.y));
    }

    private void CalculateRayOrigin()
    {
        // Box values
        Vector2 position = (Vector2)transform.position;
        Vector2 scale = (Vector2)transform.localScale;
        Vector2 size = m_boxCollider2D.size;
        Vector2 offset = m_boxCollider2D.offset;
        Vector2 center = position + new Vector2(offset.x * scale.x, offset.y * scale.y);

        float halfWidth = size.x * 0.5f;
        float halfHeight = size.y * 0.5f;

        m_bottomLeft = center + Vector2.down * (halfHeight - m_skinWidth) + Vector2.left * (halfWidth - m_skinWidth);
    }

    private bool LandingSequence(Collision2D collision)
    {
        bool land = LandVelocityCheck();

        // If it is a platform, check if we hit from above
        string objLayerName = LayerMask.LayerToName(collision.gameObject.layer);
        if (land && string.Equals(objLayerName, "Platform"))
        {
            CalculateRayOrigin();
            land = LandFromAbove(collision.transform);
        }

        return land;
    }

    private bool LandFromAbove(Transform landTarget)
    {
        // Ray origin
        Vector2 rayOrigin = m_bottomLeft;

        // Ray Direction
        Vector2 rayDirection = Vector2.down;

        // Length of ray
        float rayDistance = m_rayDistance + m_skinWidth;

        Vector2 shootFrom = rayOrigin;
        bool fromAbove = false;
        for (int i = 0; i < m_totalVerticalRays; i++)
        {
            // Point to shoot this ray from
            shootFrom.x = rayOrigin.x + m_verticalRayInterval * i;
            shootFrom.y = rayOrigin.y;

            m_rayShooter2D.Shoot(shootFrom, rayDirection, m_groundMask, rayDistance);
            //Debug.DrawRay(shootFrom, rayDirection * rayDistance, Color.red);

            if (!m_rayShooter2D.Hit)
            {
                // No hit, continue to next ray
                continue;
            }
            else if (landTarget == m_rayShooter2D.IntersectedTransform())
            {
                // Landing from above. Stop searching
                fromAbove = true;
                break;
            }
        }
        return fromAbove;
    }
    
    private void KillMe()
    {
        gameObject.SetActive(false);

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
    
    private float GravityScale()
    {
        float altitude = Mathf.Min(Altitude(), m_startAltitude);
        float gravityScale =  m_gravityScaleOffset + (1.0f - (altitude / m_startAltitude));
        return gravityScale;
    }

    public void FireThruster(bool buttonPressed)
    {
        if (buttonPressed && m_fuel > 0.0f)
        {
            m_rigidbody2D.AddForce(m_thruster.ThrustForce());

            m_fuel -= m_fuelUsePerSecond * Time.deltaTime;

            // Enable flame
            thrusterFlame.SetActive(true);

            if (!audioSources[0].isPlaying && !audioSources[1].isPlaying /*&& !audioSources[2].isPlaying*/)
            {
                audioSources[0].Play();
                audioSources[1].Play();
                audioSources[2].Play();
            }
        }
        else
        {
            // Disable flame
            thrusterFlame.SetActive(false);

            if (audioSources[0].isPlaying || audioSources[1].isPlaying)
            {
                audioSources[3].time = 0.2f;
                audioSources[3].Play();
                audioSources[0].Stop();
                audioSources[1].Stop();
                audioSources[2].Stop();
            }
        }       
    }
}
