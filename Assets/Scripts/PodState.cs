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
}
