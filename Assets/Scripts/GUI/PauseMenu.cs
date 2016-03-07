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
    private GameObject screen;
    private GameObject gui;
    private GameObject Handler;
    private InputHandler Ihandler;
    private LevelManager levelManager;

    void Awake () {
        paused = false;
        screen = GameObject.Find("GUIManager/Pause Screen/Layout");
        screen.SetActive(false);
        gui = GameObject.Find("GUIManager/Velocity_Element");
        Handler = GameObject.Find("Input Handler");
        Ihandler = Handler.GetComponent<InputHandler>();
        levelManager = transform.root.GetComponent<LevelManager>();
    }
	
	void Update ()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        if(Ihandler.ESC())
        {
            paused = !paused;
            if (paused)
            {
                Pause();
            }
            else
            {
                ReturnGame();
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

    public void Pause()
    {
        Time.timeScale = 0;
        screen.SetActive(true);
        //gui.SetActive(false); // Mikko: there is no reason to hide it. It also causes bugs
    }

    public void ReturnGame()
    {
        Time.timeScale = 1;
        screen.SetActive(false);
        //gui.SetActive(true); // Mikko: there is no reason to hide it. It also causes bugs
    }

    public void MainMenu()
    {
        if(levelManager)
            levelManager.LoadLevel(0);
    }
}

