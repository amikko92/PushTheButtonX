using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGame : ObjectState
{

    Canvas canvas;
    private GameObject lost;
    private GameObject win;
    private Text lostText;
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void InitStartState()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
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
        canvas.enabled = true;
        win.SetActive(true);
    }

    protected override void WinState()
    {

    }

    protected override void InitLoseState()
    {
        canvas.enabled = true;
        lost.SetActive(true);
    }

    protected override void LoseState()
    {
    }
}