using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void UpdateHandler();

public interface ObjectState 
{
    Dictionary<string, UpdateHandler> getHandler(gameState state);  // Getter for updateHandler based on current gameState
    void ChangeState(gameState state);                              // Change the current game state of this object
}
