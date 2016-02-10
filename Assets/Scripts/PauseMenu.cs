using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public static bool paused;
    bool showControls;
    public GUISkin mySkin;
    void Awake () {
        paused = false;
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            if (paused)
                Time.timeScale = 0;
            else
            {
                Time.timeScale = 1;
            }
        }
    }
    void OnGUI()
    {
        if (paused)
        {
            GUI.skin = mySkin;
            GUIStyle st = GUI.skin.GetStyle("Label");
            st.fontSize = 100;
            st.fontStyle = FontStyle.Bold;

            GUIStyle st2 = GUI.skin.GetStyle("Label");
            st2.fontSize = 40;
            st2.fontStyle = FontStyle.Bold;


            st.alignment = TextAnchor.UpperCenter;
            st2.alignment = TextAnchor.UpperCenter;

            GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 250, 500, 150), "Game is paused", st);
            GUI.Label(new Rect(Screen.width / 2 - 450, Screen.height / 2 - 200, 900, 150), "Press ESC to continue", st2);

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100, 200, 100), "Main Menu"))
            {
                //GameObject fade = new GameObject();
                //Fade fout = fade.AddComponent<Fade>();
                //fout.texture.color = Color.black;
                //Application.LoadLevel("MainMenu");
                paused = false;
                Time.timeScale = 1;
            }
            Application.Quit();
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "Exit Game"))
                Application.Quit();


        }
    }
}

