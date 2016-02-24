using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGame : ObjectState
{

    Canvas canvas;
    private GameObject lost;
    private GameObject win;
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
        win.SetActive(true);
    }

    protected override void WinState()
    {

    }

    protected override void InitLoseState()
    {
        lost.SetActive(true);
    }

    protected override void LoseState()
    {
    }
}