using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGame : ObjectState
{

    Canvas canvas;
    private GameObject lost;
    private GameObject win;
    private GameObject gui;
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void InitStartState()
    {
        canvas = GetComponent<Canvas>();
        lost = GameObject.Find("Lost");
        lost.SetActive(false);
        win = GameObject.Find("Won");
        win.SetActive(false);
        gui = GameObject.Find("Velocity_Element");
    }

    protected override void StartState()
    {
    }

    protected override void InitPlayState()
    {
    }

    protected override void PlayState()
    {
    }

    protected override void InitWinState()
    {
        gui.SetActive(false);
        win.SetActive(true);
    }

    protected override void WinState()
    {

    }

    protected override void InitLoseState()
    {
        gui.SetActive(false);
        lost.SetActive(true);
    }

    protected override void LoseState()
    {
    }
}