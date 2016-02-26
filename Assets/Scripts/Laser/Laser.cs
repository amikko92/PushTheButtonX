using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Laser : ObjectState {

    private ObjectState m_state;

    [SerializeField]
    protected LineRenderer _beam;

    [SerializeField]
    protected bool trackPlayer;

    private Laser m_laser;
    private GameObject _go;
    private Transform m_pod;

    [SerializeField]
    protected bool startActive;

    [SerializeField]
    protected bool constant;

    private float _offset = 0, _acc = 0.02f, _speed = 0.0f;
    public int size, startPoint, endPoint;
    float timer;
    Vector3 _position;
    LineRenderer m_beam;
    List<Vector3> vertexPositions;

    bool shot;

    protected override void Awake () {
        base.Awake();
        _go = GameObject.Find("Pod");
        m_pod = _go.GetComponent<Transform>();
        m_laser = GetComponent<Laser>();
        m_beam = GetComponentInChildren<LineRenderer>();

        m_laser.gameObject.SetActive(startActive);
        m_beam.gameObject.SetActive(false);
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
        timer = 0.0f;
        shot = false;
    }

    protected override void PlayState()
    {
        timer += Time.deltaTime;
        if (m_laser.trackPlayer)
        {
            if (timer < 2)
            {
                UpdateSpeed();
                UpdatePosition();
            }
            else if (timer > 2 && timer < 2.5)
            {

            }

            else
            {
                ShootBeam();
            }
        }

        else if(constant)
        {
            ShootBeam();
        }

        // TODO: create pulse function
        else
        {

        }

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

    private void UpdateSpeed()
    {
        if (m_laser.transform.position.y < m_pod.transform.position.y - _offset)
            _speed += System.Math.Abs(_acc);
        else if (m_laser.transform.position.y > m_pod.transform.position.y + _offset)
            _speed += System.Math.Abs(_acc) * (-1);

        float max = 0.3f;
        if (System.Math.Abs(_speed) > max)
        {
            if (_speed < 0.0f) _speed = (-1) * max;
            else _speed = max;
        }

    }

    private void UpdatePosition()
    {
        _position = m_laser.transform.position;
        _position.y = _position.y + _speed;
        m_laser.transform.position = _position;
    }

    private void InitBeam()
    {
        BoxCollider2D bc = m_laser.GetComponent<BoxCollider2D>();
        bc.enabled = true;

        shot = true;
        vertexPositions = new List<Vector3>();
        vertexPositions.Add(new Vector3(startPoint, 0, 0));

        for (int i = 1; i < size - 1; i++)
        {
            vertexPositions.Add(new Vector3((startPoint - i * (startPoint + Mathf.Abs(endPoint)) / size), 0, 0));
        }

        vertexPositions.Add(new Vector3(endPoint, 0, 0));

        m_beam.gameObject.SetActive(true);
    }

    private void UpdateBeam()
    {
        for (int i = 1; i < vertexPositions.Count - 1; i++)
        {
            Vector3 vec = vertexPositions[i];
            vec.y = Random.Range(-0.5f, 0.5f);
            m_beam.SetPosition(i, vec);
        }
    }

    private void ShootBeam()
    {
        if (!shot) InitBeam();
        UpdateBeam();
    }

}
