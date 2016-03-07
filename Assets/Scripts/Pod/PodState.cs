using UnityEngine;
using System.Collections;

public class PodState : ObjectState
{
    private DropPod m_pod;
    private GameObject Handler;
    private InputHandler Ihandler;

    protected override void Awake()
    {
        base.Awake();
        m_pod = GetComponent<DropPod>();

        Handler = GameObject.Find("Input Handler");
        Ihandler = Handler.GetComponent<InputHandler>();
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
        bool pressed = Ihandler.Held();//Input.GetKey(KeyCode.Space);
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

        // Summon explosion particle system

    }

    protected override void LoseState()
    {
    }
}
