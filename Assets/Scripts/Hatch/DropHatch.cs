using UnityEngine;
using System.Collections;

public class DropHatch : MonoBehaviour 
{
    [SerializeField]
    private Rigidbody2D m_podRigidbody;

    [SerializeField]
    private Vector2 m_ejectForce;

    // E-man
    private GameObject motherShipExplosion; 

    private Collider2D m_collider2D;

    private ObjectState m_objectState;
    private GameObject Handler;
    private InputHandler Ihandler;

    private void Awake() 
	{
        m_collider2D = GetComponent<Collider2D>();

        // E-man - Begin
        motherShipExplosion = GameObject.Find("Explosion");

        if (motherShipExplosion)
        {
            motherShipExplosion.SetActive(false);
        }
        else
        {
            Debug.Log("DopHatch::Awake(), Hey buddy! Can't find your explosion guy!");
        }
        // E-man - End

        m_objectState = GetComponent<ObjectState>();

        Handler = GameObject.Find("Input Handler");
        Ihandler = Handler.GetComponent<InputHandler>();
    }
	
	private void Update() 
	{
        // TODO: Add this line when game states are in place
        // m_objectState.UpdateState();

        // TODO: Remove the two if-statements when game states are in place
        if (!m_collider2D.enabled)
            return;

        if(Ihandler.Pressed())
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
        // E-man: Add explosion        
        motherShipExplosion.SetActive(true);
        motherShipExplosion.transform.SetParent(null);

        transform.root.gameObject.SetActive(false);
    }
}
