using UnityEngine;
using System.Collections;

public class HatchState : ObjectState
{
    private DropHatch m_hatch;

    protected override void Awake()
    {
        base.Awake();
        m_hatch = GetComponent<DropHatch>();
    }
    
    protected override void InitStartState()
    {
    }

    protected override void StartState()
    {
        // TODO: Has the camera reached the top

        bool pressed = Input.GetKeyDown(KeyCode.Space);
        if(pressed)
        {
            m_hatch.EjectPod();
            m_hatch.DestroyMotherShip();

            // TODO: Tell game manager to start play state
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
