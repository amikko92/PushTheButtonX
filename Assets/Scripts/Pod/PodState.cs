using UnityEngine;
using System.Collections;

public class PodState : ObjectState
{
    private DropPod m_pod;

    protected override void Awake()
    {
        base.Awake();
        m_pod = GetComponent<DropPod>();
    }
    
    protected override void InitStartState()
    {
    }

    protected override void StartState()
    {
    }

    protected override void InitPlayState()
    {
    }

    protected override void PlayState()
    {
        bool pressed = Input.GetKey(KeyCode.Space);
        m_pod.FireThruster(pressed);
    }

    protected override void InitWinState()
    {
        m_pod.FireThruster(false);
    }

    protected override void WinState()
    {
    }

    protected override void InitLoseState()
    {
        m_pod.FireThruster(false);
        m_pod.gameObject.SetActive(false);
    }

    protected override void LoseState()
    {
    }
}
