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
        gui = GameObject.Find("Velocity_Element");
        one = GameObject.Find("One Star");
        two = GameObject.Find("Two Stars");
        three = GameObject.Find("Three Stars");
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
        if (star == 1)
        {
            one.SetActive(true);
        }
        else if (star == 2)
        {
            two.SetActive(true);
        }
        else
        {
            three.SetActive(true);
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