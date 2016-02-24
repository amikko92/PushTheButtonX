using UnityEngine;
using System.Collections;

public class DropHatch : MonoBehaviour 
{
    private Rigidbody2D m_podRigidbody;

    [SerializeField]
    private Vector2 m_ejectForce;

    [SerializeField]
    private ParticleSystem m_motherShipExplosion;
    ParticleSystem.EmissionModule em;

    private Collider2D m_collider2D;

    private ObjectState m_objectState;
    private GameObject Handler;
    private InputHandler Ihandler;

    private void Awake() 
	{
        m_collider2D = GetComponent<Collider2D>();
        em = m_motherShipExplosion.emission;

        em.enabled = false;

        m_objectState = GetComponent<ObjectState>();

        Handler = GameObject.Find("Input Handler");
        Ihandler = Handler.GetComponent<InputHandler>();

        GameObject go = GameObject.Find("Pod");
        m_podRigidbody = go.GetComponent<Rigidbody2D>();
    }
	
	private void Update() 
	{
        m_objectState.UpdateState();

        // TODO: Remove the two if-statements when game states are in place
       /* if (!m_collider2D.enabled)
            return;

        if(Ihandler.Pressed())
        {
            EjectPod();
            DestroyMotherShip();
            GameManager.Instance.ChangeState(gameState.PLAY);
        }*/
	}

    public void EjectPod()
    {
        m_collider2D.enabled = false;
        if (m_podRigidbody != null)
        {
            m_podRigidbody.AddForce(m_ejectForce);
        }
    }

    public void DestroyMotherShip()
    {
        m_motherShipExplosion.time = 0.0f;
        em.enabled = true;
        m_motherShipExplosion.loop = false;

        m_motherShipExplosion.transform.SetParent(null);

        transform.root.gameObject.SetActive(false);
    }
}
