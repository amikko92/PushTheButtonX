using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadNextLevel()
    {
        GameManager.Instance.Nullify(true);
        int curScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curScene + 1);
    }

    public void LoadLevel(int buildIndex)
    {
        GameManager.Instance.Nullify(true);
        SceneManager.LoadScene(buildIndex);
    }

    public void RedoLevel()
    {
        GameManager.Instance.Nullify(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
