using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void UpdateHandler();

public abstract class ObjectState : MonoBehaviour
{
    protected Dictionary<gameState, UpdateHandler> m_stateInits;
    protected Dictionary<gameState, UpdateHandler> m_stateUpdates;
    
    protected UpdateHandler m_currentUpdate;
    
    protected virtual void Awake()
    {
        m_stateInits = new Dictionary<gameState, UpdateHandler>();

        m_stateInits.Add(gameState.START, InitStartState);
        m_stateInits.Add(gameState.PLAY, InitPlayState);
        m_stateInits.Add(gameState.WIN, InitWinState);
        m_stateInits.Add(gameState.LOSE, InitLoseState);

        m_stateUpdates = new Dictionary<gameState, UpdateHandler>();
        
        m_stateUpdates.Add(gameState.START, StartState);
        m_stateUpdates.Add(gameState.PLAY, PlayState);
        m_stateUpdates.Add(gameState.WIN, WinState);
        m_stateUpdates.Add(gameState.LOSE, LoseState);
        
        ChangeState(gameState.START);

        GameManager.Instance.AddListener(this);
    }

    public void UpdateState()
    {
        m_currentUpdate();
    }

    // Change the current game state of this object
    public void ChangeState(gameState state)
    {
        UpdateHandler init;
        bool success = m_stateInits.TryGetValue(state, out init);
        if (success)
        {
            init();
        }
        else
        {
            Debug.LogError("Could not find delegate method for init of state: " + state);
        }
        
        success = m_stateUpdates.TryGetValue(state, out m_currentUpdate);
        if(!success)
        {
            Debug.LogError("Could not find delegate method for state: " + state);
        }
    }

    protected abstract void InitStartState();
    protected abstract void StartState();

    protected abstract void InitPlayState();
    protected abstract void PlayState();

    protected abstract void InitWinState();
    protected abstract void WinState();

    protected abstract void InitLoseState();
    protected abstract void LoseState();
}
