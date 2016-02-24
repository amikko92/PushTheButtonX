using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseMenu : MonoBehaviour {

    public static bool paused;
    bool showControls;
    public GUISkin mySkin;
    Canvas canvas;
    private GameObject screen;
    private GameObject Handler;
    private InputHandler Ihandler;

    void Awake () {
        paused = false;
        canvas = GetComponent<Canvas>();
        screen = GameObject.Find("Layout");
        screen.SetActive(false);
        Handler = GameObject.Find("Input Handler");
        Ihandler = Handler.GetComponent<InputHandler>();
    }
	
	void Update ()
    {
        if (Ihandler.ESC())
        {
            paused = !paused;
            if (paused)
            {
                Time.timeScale = 0;
                screen.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                screen.SetActive(false);
            }
        }
    }
    public void Quit()
    {
        #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
    public void ReturnGame()
    {
        Time.timeScale = 1;
        screen.SetActive(false);
    }
}

