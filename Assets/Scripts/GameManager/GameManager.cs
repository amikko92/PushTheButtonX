using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum gameState { START, PLAY, WIN, LOSE };

public class GameManager : MonoBehaviour {

    // Singleton that is returned when instanciating the GameManager
    private static GameManager _instance = null;

    private List<ObjectState> _listeners = new List<ObjectState>();
    private gameState _currentState;
    private GameManager() { }

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject singleton = new GameObject();
                _instance = singleton.AddComponent<GameManager>();
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
            listener.ChangeState(_currentState);
        }
    }

    public void ChangeState(gameState state)
    {
        _currentState = state;
        Notify();
    }
    public void Nullify(bool nulli)
    {
        GameManager._instance = null;
    }
}
