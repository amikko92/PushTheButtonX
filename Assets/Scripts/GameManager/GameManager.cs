using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum gameState { START, PLAY, WIN, LOSE };

public class GameManager : MonoBehaviour {

    // Singleton that is returned when instanciating the GameManager
    private static GameManager _instance;

    private List<ObjectState> _listeners = new List<ObjectState>();
    private gameState _currentState;
    private GameManager() { }

    public static GameManager Instance
    {
        get
        {
            _instance = GameObject.FindObjectOfType(typeof(GameManager)) as GameManager;

            if (_instance == null)
            {
                GameObject singleton = new GameObject();
                _instance = singleton.AddComponent<GameManager>();
                singleton.name = "(singleton) " + typeof(GameManager).ToString();

                DontDestroyOnLoad(singleton);

                Debug.Log("[Singleton] An instandce of "
                    + typeof(GameManager) + " is needed in the scene, so '"
                    + singleton + "'was created with DontDestroyOnLoad.");

            } else { 
                Debug.Log("[Singleton] Using instance already created: " +
                _instance.gameObject.name);
            }
                    
            return _instance;
        }
    }

   public void AddListener(ObjectState listener)
    {
        _listeners.Add(listener);
    }

    void RemoveListener(ObjectState listener)
    {
        _listeners.Remove(listener);
    }

    void Notify()
    {
        foreach (var listener in _listeners)
        {
            Debug.Log("Changing object state");
            listener.ChangeState(_currentState);
        }
    }

    public void ChangeState(gameState state)
    {
        Debug.Log("Game state change");
        _currentState = state;
        Notify();
    }
}
