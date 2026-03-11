using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputService 
{
    public event Action<Vector2> OnMoveChanged;
    public event Action OnJumpPerformed;

    Vector2 MoveInput();
    void Disable();
}
