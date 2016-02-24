using UnityEngine;
using System.Collections;
using System;

public class PCInput : InputHandler
{

    public override bool Pressed()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
    public override bool Released()
    {
        return Input.GetKeyUp(KeyCode.Space);
    }
    public override bool Held()
    {
        return Input.GetKey(KeyCode.Space);
    }
    public override bool ESC()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }
}
