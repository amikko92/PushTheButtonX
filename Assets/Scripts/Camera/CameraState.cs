using UnityEngine;
using System.Collections;

public class CameraState : ObjectState
{
    private CameraMovement m_cam;
    protected override void Awake()
    {
        base.Awake();
        m_cam = GetComponent<CameraMovement>();
    }

    protected override void InitStartState()
    {
    }

    protected override void StartState()
    {
        m_cam.GameStart();
    }

    protected override void InitPlayState()
    {
        m_cam.GamePlay();
    }

    protected override void PlayState()
    {
    }

    protected override void InitWinState()
    {
    }

    protected override void WinState()
    {
        m_cam.EndGame();
    }

    protected override void InitLoseState()
    {
    }

    protected override void LoseState()
    {
        m_cam.EndGame();
    }
}