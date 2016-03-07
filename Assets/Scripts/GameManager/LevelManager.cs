using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadNextLevel()
    {
        Time.timeScale = 1.0f;
        GameManager.Instance.Nullify(true);
        int curScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curScene + 1);
    }

    public void LoadLevel(int buildIndex)
    {
        Time.timeScale = 1.0f;
        GameManager.Instance.Nullify(true);
        SceneManager.LoadScene(buildIndex);
    }

    public void RedoLevel()
    {
        Time.timeScale = 1.0f;
        GameManager.Instance.Nullify(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void StartGame()
    {

        GameManager.Instance.Nullify(true);
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        GameManager.Instance.Nullify(true);

        // Mikko: Never hard code scene loading. My quick fix is also bad
        //SceneManager.LoadScene("Menu");  
        SceneManager.LoadScene(0);
    }
}
