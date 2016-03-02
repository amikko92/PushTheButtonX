#if UNITY_EDITOR

using UnityEngine;
using System.Collections;

public class EditorGizmo : MonoBehaviour
{
    [SerializeField]
    private float m_radius = 0.5f;
    [SerializeField]
    private Color m_color = Color.white;

    private void OnDrawGizmos()
    {
        Gizmos.color = m_color;
        Gizmos.DrawSphere(transform.position, m_radius);
    }
}

#endif
