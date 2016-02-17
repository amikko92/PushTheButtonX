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

    // Temp update for testing
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeState(gameState.START);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeState(gameState.PLAY);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeState(gameState.WIN);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeState(gameState.LOSE);
        }
    }

    protected override void InitStartState()
    {
        Debug.Log("init start state");
    }

    protected override void StartState()
    {
        Debug.Log("start state");
    }

    protected override void InitPlayState()
    {
        Debug.Log("init play state");
    }

    protected override void PlayState()
    {
        Debug.Log("play state");
    }

    protected override void InitWinState()
    {
        Debug.Log("init win state");
    }

    protected override void WinState()
    {
        Debug.Log("win state");
    }

    protected override void InitLoseState()
    {
        Debug.Log("init lose state");
    }

    protected override void LoseState()
    {
        Debug.Log("lose state");
    }
}
