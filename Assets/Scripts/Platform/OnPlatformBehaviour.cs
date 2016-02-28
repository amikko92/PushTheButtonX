using UnityEngine;
using System.Collections;

public class OnPlatformBehaviour : MonoBehaviour
{
    private Transform m_transform;
    private Rigidbody2D m_rigidbody2D;

    private void Awake()
    {
        m_transform = transform;
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Translate(Vector3 delta)
    {
        m_transform.Translate(delta);
    }

    public void AddForce(Vector2 force)
    {
        m_rigidbody2D.AddForce(force);
    }
}
