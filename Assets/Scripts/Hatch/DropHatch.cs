using UnityEngine;
using System.Collections;

public class DropHatch : MonoBehaviour 
{
    private Rigidbody2D m_podRigidbody;

    [SerializeField]
    private Vector2 m_ejectForce;

    // E-man
    private GameObject motherShipExplosion;
    private AudioSource as_explosion;
    private bool setToDestroy = false;

    [SerializeField]
    private GameObject shipMesh;

    private Collider2D m_collider2D;

    private ObjectState m_objectState;
    private GameObject Handler;
    private InputHandler Ihandler;

    private void Awake() 
	{
        m_collider2D = GetComponent<Collider2D>();

        // E-man - Begin
        motherShipExplosion = GameObject.Find("MotherShipExplosion");

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

        GameObject go = GameObject.Find("Pod");
        m_podRigidbody = go.GetComponent<Rigidbody2D>();

        // E-man
        as_explosion = GetComponent<AudioSource>();
    }
	
	private void Update() 
	{
        m_objectState.UpdateState();

        if(setToDestroy)
        {
            if(!as_explosion.isPlaying)
            {
                setToDestroy = false;
                transform.root.gameObject.SetActive(false);
                
            }
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
                
        as_explosion.Play();
        setToDestroy = true;

        shipMesh.SetActive(false);
        // transform.root.gameObject.SetActive(false); 
    }
}
