using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Laser entity that shoots a beam that destroys the player
/// if they touch.
/// 
/// 
/// Different modes
/// 
/// TrackPlayer:
///     Tracks the player for a ceratin amount of time
///     has a charge time before shooting a beam.
/// 
/// Constant:
///     Shoots a beam  constantly
/// 
/// Pulsate:
///     Pulsates a beam for a certain length for on/off    
/// 
/// </summary>
public class Laser : ObjectState {

    [SerializeField]
    protected LineRenderer _beam;

    [SerializeField]
    private bool    startActive, 
                    constant, 
                    pulse, 
                    trackPlayer;

    [SerializeField]
    private int pulseLength;

    // Used to find the Pod
    private GameObject _go;
    private Transform m_pod;

    private Laser m_laser;
    private Vector3 _position;

    private bool    _toggle,
                    _shoot,
                    _shot;

    private float   _timer,
                    _pulseTimer,
                    m_acc = 0.02f,
                    m_speed = 0.0f,
                    m_altitude = 1.0f,
                    _trackDuration = 2.0f,
                    _chargeDuration = 2.5f;

    // Used to turn on/off collisions
    private BoxCollider2D m_beam_bc;
   

    // Varibles needed to wrap the vertex positions of the LineRenderer
    private LineRenderer m_beam;
    private List<Vector3> vertexPositions;
    // NOTE: These variables will modify the LineRenderer
    private int _size = 30, _startPoint = 17, _endPoint = -17;


    protected override void Awake () {
        base.Awake();
        _go = GameObject.Find("Pod");
        m_pod = _go.GetComponent<Transform>();
        m_laser = GetComponent<Laser>();
        m_beam = GetComponentInChildren<LineRenderer>();

        m_laser.gameObject.SetActive(startActive);
        m_beam.gameObject.SetActive(false);

        m_beam_bc = m_laser.GetComponent<BoxCollider2D>();
        m_beam_bc.enabled = false;
    }
	
	void Update () {
        UpdateState();
	}

    void OnTriggerStay2D(Collider2D col)
    {
        DropPod pod = col.GetComponent<DropPod>();
        if (pod != null) pod.EnemyHit();
    }


    //----------------------------------------------------------------
    // STATES
    //----------------------------------------------------------------

    protected override void InitStartState()
    {
    }

    protected override void StartState()
    {
    }

    protected override void InitPlayState()
    {
        _timer = 0.0f;
        _shot = false;
    }

    protected override void PlayState()
    {
        bool shoot = false;
        _timer += Time.deltaTime;

        // NOTE: Order matters, last if-statement is prioritized
        if (m_laser.trackPlayer)
        {
            TrackPlayer(ref shoot);
        }

        if (constant) shoot = true;
        
        if (pulse)
        {
            PulseBeam(ref shoot);
        }

        if (shoot) ShootBeam();

    }

    protected override void InitWinState()
    {
    }

    protected override void WinState()
    {
    }

    protected override void InitLoseState()
    {
    }

    protected override void LoseState()
    {
    }

    //---------------------------------------------------------
    // PRIVATE METHODS
    //---------------------------------------------------------

    /// <summary>
    /// Simple accelartion of the speed while the emitters are tracking the enemy.
    /// 
    /// Offset is used to prevent the emitters from getting "glued" to the player
    /// while tracking.
    /// 
    /// </summary>
    private void UpdateSpeed()
    {
        if (m_laser.transform.position.y < m_pod.transform.position.y)
            m_speed += System.Math.Abs(m_acc);
        else if (m_laser.transform.position.y > m_pod.transform.position.y)
            m_speed += System.Math.Abs(m_acc) * (-1);

        float max = 0.3f;
        if (System.Math.Abs(m_speed) > max)
        {
            if (m_speed < 0.0f) m_speed = (-1) * max;
            else m_speed = max;
        }

    }

    /// <summary>
    /// Updates the position of the laser based on the current speed
    /// </summary>
    private void UpdatePosition()
    {
        _position = m_laser.transform.position;
        _position.y = _position.y + m_speed;
        m_laser.transform.position = _position;
    }

    /// <summary>
    /// Before shooting the beam we need to turn on the collider.
    /// 
    /// We also need the initialize and position all the vertices
    /// for the line renderer.
    /// 
    /// TODO: Find a way to get the vertex points and make the count
    /// modular.
    /// 
    /// </summary>
    private void InitBeam()
    {
        m_beam_bc.enabled = true;

        _shot = true;
        vertexPositions = new List<Vector3>();
        vertexPositions.Add(new Vector3(_startPoint, 0, 0));

        for (int i = 1; i < _size - 1; i++)
        {
            vertexPositions.Add(new Vector3((_startPoint - i * (_startPoint + Mathf.Abs(_endPoint)) / _size), 0, 0));
        }

        vertexPositions.Add(new Vector3(_endPoint, 0, 0));

        m_beam.gameObject.SetActive(true);
    }

    /// <summary>
    /// Updates each vertex, except the end points,  and positons them at y-location 
    /// based on the altitude.
    /// </summary>
    private void UpdateBeam()
    {
        for (int i = 1; i < vertexPositions.Count - 1; i++)
        {
            Vector3 vec = vertexPositions[i];
            vec.y = Random.Range(-(m_altitude/2), (m_altitude));
            m_beam.SetPosition(i, vec);
        }
    }

    private void ShootBeam()
    {
        if (!_shot) InitBeam();
        UpdateBeam();
    }

    /// <summary>
    /// Tracks the player for the duration of _trackDuration
    /// Gives visual cue for the duration of _chargeDuration
    /// Get into shoot state after the duration of _trackDuration + _chargeDuration
    /// </summary>
    /// <param name="shoot"> refrence to decide if the beam should shoot or not</param>
    private void TrackPlayer(ref bool shoot)
    {
        if (_timer < _trackDuration)
        {
            UpdateSpeed();
            UpdatePosition();
        }
        else if (_timer > _trackDuration && _timer < (_trackDuration + _chargeDuration))
        {
            // Implement charge laser transition
        }

        else
        {
            shoot = true;
        }
    }

    /// <summary>
    /// Pulsates the beam with a length of pulseLength
    /// where the on/off have the same duration.
    /// 
    /// Also disables the hit box when the beam is toggled
    /// of.
    /// </summary>
    /// <param name="shoot">refrence to decide if the beam should shoot or no</param>
    private void PulseBeam(ref bool shoot)
    {
        _pulseTimer += Time.deltaTime;

        if (_pulseTimer > pulseLength)
        {
            // NOTE: The order matters
            _toggle = !_toggle;
            m_beam.gameObject.SetActive(_toggle);
            m_beam_bc.enabled = _toggle;

            _pulseTimer = 0;
        }

        if (_toggle) shoot = true;
    }
    
}
