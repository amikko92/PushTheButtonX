using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum gameState { START, PLAY, WIN, LOSE };

public class GameManager : MonoBehaviour {

    // Singleton that is returned when instanciating the GameManager
    private static GameManager instance;

    private List<ObjectState> listeners = new List<ObjectState>();
    private gameState currentState;

    private GameManager() { }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType(typeof(GameManager)) as GameManager;
            return instance;
        }
    }

    void AddListener(ObjectState listener)
    {
        listeners.Add(listener);
    }

    void RemoveListener(ObjectState listener)
    {
        listeners.Remove(listener);
    }

    void Notify()
    {
        foreach (var listener in listeners)
        {
            listener.ChangeState(currentState);
        }
    }
}
