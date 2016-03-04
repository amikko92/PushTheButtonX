using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGame : ObjectState
{

    private GameObject lost;
    private GameObject win;
    private GameObject gui;
    private GameObject grader;
    private GameObject one;
    private GameObject two;
    private GameObject three;
    private GameObject zero;
    private Grade grade;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void InitStartState()
    {
        lost = GameObject.Find("Lost");
        lost.SetActive(false);
        win = GameObject.Find("Won");
        win.SetActive(false);
        gui = GameObject.Find("HUD");
        zero = GameObject.Find("No Star");
        one = GameObject.Find("One Star");
        two = GameObject.Find("Two Stars");
        three = GameObject.Find("Three Stars");
        zero.SetActive(false);
        one.SetActive(false);
        two.SetActive(false);
        three.SetActive(false);
        grader = GameObject.Find("Grading");
        grade = grader.GetComponent<Grade>();
        Time.timeScale = 1;
    }

    protected override void StartState()
    {
    }

    protected override void InitPlayState()
    {
        grade.StartTime();
    }

    protected override void PlayState()
    {
    }

    protected override void InitWinState()
    {
        grade.EndTime();
        int star = grade.CalculateGrade();
        switch(star)
        {
            case 0:
                zero.SetActive(true);
                break;
            case 1:
                one.SetActive(true);
                break;
            case 2:
                two.SetActive(true);
                break;
            case 3:
                three.SetActive(true);
                break;
        }
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