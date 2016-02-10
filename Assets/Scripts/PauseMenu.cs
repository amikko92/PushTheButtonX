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
    void Awake () {
        paused = false;
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            canvas.enabled = !canvas.enabled;
            if (paused)
                Time.timeScale = 0;
            else
            {
                Time.timeScale = 1;
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
}

