using UnityEngine;
using System.Collections;

public class DropHatch : MonoBehaviour 
{
    [SerializeField]
    private Rigidbody2D m_podRigidbody;

    [SerializeField]
    private Vector2 m_ejectForce;

    [SerializeField]
    private ParticleSystem m_motherShipExplosion;
    ParticleSystem.EmissionModule em;

    private Collider2D m_collider2D;

    private ObjectState m_objectState;
    
	private void Awake() 
	{
        m_collider2D = GetComponent<Collider2D>();
        em = m_motherShipExplosion.emission;

        em.enabled = false;

        m_objectState = GetComponent<ObjectState>();
    }
	
	private void Update() 
	{
        // TODO: Add this line when game states are in place
        // m_objectState.UpdateState();

        // TODO: Remove the two if-statements when game states are in place
        if (!m_collider2D.enabled)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            EjectPod();
            DestroyMotherShip();
            GameManager.Instance.ChangeState(gameState.PLAY);
        }
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
        
        transform.root.gameObject.SetActive(false);
    }
}
