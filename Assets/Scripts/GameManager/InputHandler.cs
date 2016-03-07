using UnityEngine;
using System.Collections;

public abstract class InputHandler : MonoBehaviour
{

    public abstract bool Released();
    public abstract bool Pressed();
    public abstract bool Held();
    public abstract bool ESC();
}