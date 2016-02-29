using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.SceneManagement;


public class MainMenuScripts : MonoBehaviour {

    private GameObject pod;
    private DropPod dp;
    public GameObject main;
    public GameObject select;
    Canvas canvas;
    // Use this for initialization
    void Awake ()
    {
        canvas = GetComponent<Canvas>();
       // pod = GameObject.FindGameObjectWithTag("Player");
       // dp = pod.GetComponent <DropPod> ();
        main = GameObject.Find("Main Menu");
        select = GameObject.Find("Level Select");
        main.SetActive(true);
        select.SetActive(false);
    }
	
	// Update is called once per frame
	/*void Update ()
    {
        RandomMovement();
	}
    public IEnumerator RandomMovement()
    {
        yield return new WaitForSeconds(Random.value * 10);
        dp.FireThruster(true);
        yield return new WaitForSeconds(Random.value * 10);
        dp.FireThruster(false);
    }*/
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
}
