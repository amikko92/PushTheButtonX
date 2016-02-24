using UnityEngine;
using System.Collections;

public class HatchState : ObjectState
{
    private DropHatch m_hatch;
    private InputHandler Ihandler;

    protected override void Awake()
    {
        base.Awake();
        m_hatch = GetComponent<DropHatch>();

        GameObject go = GameObject.Find("Input Handler");
        Ihandler = go.GetComponent<InputHandler>();
    }
    
    protected override void InitStartState()
    {
    }

    protected override void StartState()
    {
        // TODO: Has the camera reached the top

        bool pressed = Ihandler.Pressed();

        if (Ihandler.Pressed())
        {
            m_hatch.EjectPod();
            m_hatch.DestroyMotherShip();
            GameManager.Instance.ChangeState(gameState.PLAY);
        }
    }

    protected override void InitPlayState()
    {
    }

    protected override void PlayState()
    {
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
