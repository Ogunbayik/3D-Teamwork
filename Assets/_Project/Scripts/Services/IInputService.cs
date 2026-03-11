using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputService 
{
    public event Action<Vector2> OnMoveChanged;

    Vector2 MoveInput();
    bool IsPressedJump();
    void Disable();
}
