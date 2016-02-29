using UnityEngine;
using System.Collections;

public class HatchState : ObjectState
{
    private DropHatch m_hatch;
    private InputHandler m_inputHandler;

    private CameraMovement m_cam;

    protected override void Awake()
    {
        base.Awake();
        m_hatch = GetComponent<DropHatch>();

        GameObject go = GameObject.Find("Input Handler");
        m_inputHandler = go.GetComponent<InputHandler>();

        m_cam = Camera.main.GetComponent<CameraMovement>();
    }
    
    protected override void InitStartState()
    {
    }

    protected override void StartState()
    {
        // Add this when at top works
        if (!m_cam.AtTop()) return;

        if (m_inputHandler.Pressed())
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
