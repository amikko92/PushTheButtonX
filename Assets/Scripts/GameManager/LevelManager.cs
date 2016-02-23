using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void ChangeLevel()
    {
        GameManager.Instance.Nullify(true);
        SceneManager.LoadScene("New E-man");
    }
    public void RedoLevel()
    {
        GameManager.Instance.Nullify(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
