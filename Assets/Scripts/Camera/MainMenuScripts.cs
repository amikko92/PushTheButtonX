using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.SceneManagement;


public class MainMenuScripts : MonoBehaviour {

    public GameObject main;
    public GameObject select;
    void Awake ()
    {
        GameManager.Instance.ChangeState(gameState.START);
        main = GameObject.Find("Main Menu");
        select = GameObject.Find("Level Select");
        main.SetActive(true);
        select.SetActive(false);
        GameManager.Instance.ChangeState(gameState.PLAY);
    }
	
    public void Quit()
    {
        #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
        #else
                        Application.Quit();
        #endif
    }

    public void StartGame()
    {
        GameManager.Instance.Nullify(true);
        SceneManager.LoadScene(1);
    }

    public void LevelSelect()
    {
        main.SetActive(false);
        select.SetActive(true);
    }

    public void LoadLevel(int level)
    {
        GameManager.Instance.Nullify(true);
        SceneManager.LoadScene(level);
    }

    public void MainMenu()
    {
        GameManager.Instance.Nullify(true);

        // Mikko: Never hard code scene loading. My quick fix is also bad
        //SceneManager.LoadScene("Menu");  
        SceneManager.LoadScene(0);
    }
}
